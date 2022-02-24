using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [SerializeField]
    private GameObject[] _tetrominoGroups;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnTetromino();
    }

    /// <summary>
    /// Spawns a random tetromino at the current postion.
    /// </summary>
    public void SpawnTetromino()
    {
        int randomIndex = Random.Range(0, _tetrominoGroups.Length - 1);
        Instantiate(_tetrominoGroups[randomIndex], transform.position, Quaternion.identity);
    }

}
