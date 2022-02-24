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
}
