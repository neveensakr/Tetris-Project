using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid : MonoBehaviour
{
    public static int GridWidth = 10;
    public static int GridHeight = 20;
    public static Transform[,] GridArray = new Transform[GridWidth, GridHeight]; // Initializes the grid array using the width and height properties.

    /// <summary>
    /// Deletes the blocks at the given row.
    /// </summary>
    /// <param name="rowYIndex">The y index of the row in the GridArray.</param>
    private static void DeleteRow(int rowYIndex)
    {
        for (int i = 0; i < GridWidth; i++)
        {
            Destroy(GridArray[i, rowYIndex].gameObject); // destroy the block
            GridArray[i, rowYIndex] = null; // reset its value in the grid array.
        }
    }

    /// <summary>
    /// Shifts the grid from the given row down by 1 row.
    /// </summary>
    /// <param name="rowYIndex">The y index of the row to start the shift in the GridArray.</param>
    private static void ShiftDown(int fromRowYIndex)
    {
        // For every row that needs to be shifted,
        for (int y = fromRowYIndex; y < GridHeight; y++)
        {
            // For every position,
            for (int x = 0; x < GridWidth; x++)
            {
                // If there is a block at the current position, shift it down.
                if (GridArray[x, y] != null)
                {
                    // Shift it in the grid array
                    GridArray[x, y - 1] = GridArray[x, y];
                    GridArray[x, y] = null;

                    // Shift it's position
                    GridArray[x, y - 1].position += new Vector3(0, -1, 0);
                }
            }
        }
    }

    /// <summary>
    /// Checks if the row at the given index is full.
    /// </summary>
    /// <param name="rowYIndex">Index of the row to check.</param>
    /// <returns>True if the row is full.</returns>
    private static bool CheckRowFull(int rowYIndex)
    {
        // Assume the row of full.
        bool isFull = true;

        for (int i = 0; i < GridWidth; i++)
        {
            // If one of the blocks if null (an empty space), break.
            if (GridArray[i, rowYIndex] == null)
            {
                isFull = false;
                break;
            }
        }

        return isFull;
    }

    /// <summary>
    /// Checks if a row is full. If it is, it deletes it and shifts the rows above downwards.
    /// </summary>
    public static void DeleteFullRows()
    {
        for (int y = 0; y < GridHeight; y++)
        {
            if (CheckRowFull(y))
            {
                DeleteRow(y);
                ShiftDown(y+1); // Shift down from the row above as the current row no longer exists.
                --y; // skip the row that we just deleted in the loop.
            }
        }
    }

    /// <summary>
    /// Rounds a Vector2 to the nearest integers. This helps in calculating grid positions.
    /// </summary>
    /// <param name="position">Vector to round</param>
    public static Vector2Int RoundVector(Vector2 position)
    {
        return new Vector2Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y));
    }

    /// <summary>
    /// Checks if the given vector is inside the grid.
    /// </summary>
    /// <param name="position">Vector to check</param>
    /// <returns>True if the vector is inside the grid.</returns>
    public static bool BorderCheck(Vector2Int position)
    {
        return position.x >= 0 && position.x < GridWidth && position.y >= 0 && position.y < GridHeight;
    }

}
