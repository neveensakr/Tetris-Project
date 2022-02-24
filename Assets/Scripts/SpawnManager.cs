using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _tetrominoGroups;

    private void Start()
    {
        SpawnTetromino();
    }

    private void SpawnTetromino()
    {
        int randomIndex = Random.Range(0, _tetrominoGroups.Length - 1);
        Instantiate(_tetrominoGroups[randomIndex], transform.position, Quaternion.identity);
    }

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
