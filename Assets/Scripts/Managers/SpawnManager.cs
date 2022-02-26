using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [SerializeField]
    private GameObject _blockingTetromino;

    [SerializeField]
    private GameObject[] _tetrominoGroups;

    [SerializeField]
    private Transform _nextBlockPos;

    public Tetromino NextBlock;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Spawn a blocker block every 30 seconds.
        InvokeRepeating("SpawnBlockingTetromino", 8.0f, 30.0f);
    }

    /// <summary>
    /// Spawns a random tetromino at the current postion.
    /// </summary>
    public void SpawnTetromino()
    {
        int randomIndex = Random.Range(0, _tetrominoGroups.Length - 1);
        if (NextBlock == null) // If there is no next block (first time to spawn), spawn a new one.
            Instantiate(_tetrominoGroups[randomIndex], transform.position, Quaternion.identity).GetComponent<Tetromino>().SetUp();
        else // Otherwise, use the existing next one.
        {
            NextBlock.gameObject.transform.position = transform.position;
            NextBlock.CanBeControlled = true;
            NextBlock.SetUp();
        }
        // Update the Next Block.
        NextBlock = Instantiate(_tetrominoGroups[randomIndex], _nextBlockPos.position, Quaternion.identity).GetComponent<Tetromino>();
        NextBlock.CanBeControlled = false;
    }

    /// <summary>
    /// This function spawn a blocking tetromino.
    /// This function gets invoked repeatedly.
    /// </summary>
    public void SpawnBlockingTetromino()
    {
        Tetromino block = Instantiate(_blockingTetromino, TetrisGrid.GetRandomPosition(), Quaternion.identity).GetComponent<Tetromino>();
        while (!block.CheckTetrominoPos())
        {
            block.gameObject.transform.position = TetrisGrid.GetRandomPosition();
        }
        block.CanBeControlled = false;
        block.UpdateTetrominoInGrid();
    }

}
