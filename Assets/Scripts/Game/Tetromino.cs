using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public bool CanBeControlled = true;
    private bool _hasLanded = false;
    private float _fallingTime = 1.5f;

    /// <summary>
    /// This Invokes the MoveDown function and checks if the game is over.
    /// </summary>
    public void SetUp()
    {
        InvokeRepeating("MoveDown", 0.1f, _fallingTime); // Fall down

        // If we collide with another block, game over.
        if (CanBeControlled && !CheckTetrominoPos())
        {
            CanBeControlled = false;
            GameManager.GameEnded();
        }
    }

    private void Update()
    {
        // If the tetromino did not land yet, we can control it.
        if (!_hasLanded && CanBeControlled)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                Move(new Vector3(-1, 0, 0)); // Move Left
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                Move(new Vector3(1, 0, 0)); // Move Right
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                // Move to new positon
                transform.Rotate(0, 0, -90); // Rotate.

                // If it is a valid positon
                if (CheckTetrominoPos())
                    UpdateTetrominoInGrid(); // Update the grid.
                else
                    transform.Rotate(0, 0, 90); // If it is not valid, go back to the previous position.
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                Move(new Vector3(0, -1, 0)); // Move Down
        }
    }

    /// <summary>
    /// Checks if the position of all the blocks in this tetromino is 
    /// valid (within the grid borders and not overlapping another blocks).
    /// </summary>
    /// <returns>True if the Tetromino is in a valid position.</returns>
    public bool CheckTetrominoPos()
    {
        foreach (Transform block in transform.GetComponentsInChildren<Transform>())
        {
            Vector2Int blockPos = TetrisGrid.RoundVector(block.position);
            // If the current block is outside the grid.
            if (!TetrisGrid.BorderCheck(blockPos))
                return false;

            // If there is another block at the same place.
            if (TetrisGrid.GridArray[blockPos.x, blockPos.y] != null)
            {
                // If there is a powerup, collect it.
                if (TetrisGrid.GridArray[blockPos.x, blockPos.y].GetComponentInParent<PowerUpBlock>() != null)
                {
                    Destroy(TetrisGrid.GridArray[blockPos.x, blockPos.y].gameObject); // remove the powerup.
                    TetrisGrid.GridArray[blockPos.x, blockPos.y] = null; // reset its position in the grid.
                    GameManager.UpdateScore(50); // update the score.
                }
                // We check the parent of the block so that when a tetromnio shifts place, it does not get affected by its own blocks.
                else if (TetrisGrid.GridArray[blockPos.x, blockPos.y].parent != transform)
                    return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Updates the value of the tetromino blocks in the Grid. 
    /// This happens when a Tetromino changes position.
    /// </summary>
    public void UpdateTetrominoInGrid()
    {
        // Remove any blocks from this tetromino from the grid.
        for (int y = 0; y < TetrisGrid.GridHeight; y++)
        {
            for (int x = 0; x < TetrisGrid.GridWidth; x++)
            {
                // If there is a block in this position that is part of this group, remove it.
                if (TetrisGrid.GridArray[x, y] != null && TetrisGrid.GridArray[x, y].parent == transform)
                    TetrisGrid.GridArray[x, y] = null;
            }
        }

        // Add them again with their new positions.
        foreach (Transform block in transform.GetComponentsInChildren<Transform>())
        {
            Vector2Int blockPos = TetrisGrid.RoundVector(block.position);
            // If the current block is outside the grid.
            TetrisGrid.GridArray[blockPos.x, blockPos.y] = block;
        }
    }


    /// <summary>
    /// Attempts to Move the tetromino in the specified direction.
    /// Calls Landed if the tetromino couldn't move down.
    /// </summary>
    private void Move(Vector3 direction)
    {
        // Move to new positon
        transform.position += direction;

        // If it is a valid positon
        if (CheckTetrominoPos())
            UpdateTetrominoInGrid(); // Update the grid.
        else
        {
            transform.position -= direction; // If it is not valid, go back to the previous position.
            if (direction == new Vector3(0, -1, 0))
                Landed();
        }
    }

    /// <summary>
    /// Deletes any full rows and spawns a new Tetromino. 
    /// This is called once the tetromino has landed on either a block or the ground.
    /// </summary>
    private void Landed()
    {
        TetrisGrid.DeleteFullRows(); // Remove any completed rows 
        if (!GameManager.GameOver) // Don't spawn another tetromino if Game Over.
            SpawnManager.Instance.SpawnTetromino(); // Spawn another tetromino as this one landed.
        _hasLanded = true;
        CanBeControlled = false;
        CancelInvoke("MoveDown"); // Stop Falling.
    }

    /// <summary>
    /// Moves the Tetromino down by one unit. 
    /// This is its own function so it can be Invoked.
    /// </summary>
    private void MoveDown()
    {
        Move(new Vector3(0, -1, 0));
    }

}