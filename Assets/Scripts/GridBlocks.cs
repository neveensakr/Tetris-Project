using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBlocks : MonoBehaviour
{
    private void Awake()
    {
        for (int x = 0; x < TetrisGrid.GridWidth; x++)
        {
            // For every row, create a row object that will store the GridBlocks for that row.
            GameObject row = new GameObject("Row " + (x + 1));
            row.transform.SetParent(transform);
            // For every object, create a Grid block and place it in where the block is.
            for (int y = 0; y < TetrisGrid.GridHeight; y++)
            {
                Instantiate(Resources.Load<GameObject>("GridBlock"), new Vector3(x, y), Quaternion.identity).transform.SetParent(row.transform);
            }
        }
    }

    // FOR DEBUG PURPOSES...
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(4.5f, 9.5f), new Vector2(TetrisGrid.GridWidth, TetrisGrid.GridHeight));
        for (int i = 0; i < TetrisGrid.GridWidth; i++)
        {
            for (int j = 0; j < TetrisGrid.GridHeight; j++)
            {
                if (TetrisGrid.GridArray[i, j] != null)
                    Gizmos.color = Color.red;
                else
                    Gizmos.color = Color.blue;
                Gizmos.DrawSphere(new Vector3(i, j, 0), 0.5f);
            }
        }
    }

}
