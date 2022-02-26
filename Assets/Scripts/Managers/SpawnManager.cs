using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [SerializeField]
    private GameObject[] _tetrominoGroups;

    [SerializeField]
    private Transform _nextBlockPos;

    public Tetromino NextBlock;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Spawns a random tetromino at the current postion.
    /// </summary>
    public void SpawnTetromino()
    {
        int randomIndex = Random.Range(0, _tetrominoGroups.Length - 1);
        if (NextBlock == null)
            Instantiate(_tetrominoGroups[randomIndex], transform.position, Quaternion.identity).GetComponent<Tetromino>().SetUp(); // Spawn the current one.
        else
        {
            NextBlock.gameObject.transform.position = transform.position;
            NextBlock.CanBeControlled = true;
            NextBlock.SetUp();
        }

        NextBlock = Instantiate(_tetrominoGroups[randomIndex], _nextBlockPos.position, Quaternion.identity).GetComponent<Tetromino>();
        NextBlock.CanBeControlled = false;
    }

}
