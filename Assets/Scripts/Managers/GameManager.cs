using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int _score;
    
    /// <summary>
    /// This updates the score variable in the GameManager.
    /// This calls the HudManager's Update score function.
    /// </summary>
    /// <param name="toAdd">Value to add to the existing score.</param>
    public static void UpdateScore(int toAdd)
    {
        _score += toAdd;
        HudManager.Instance.UpdateScore(_score);
    }

    /// <summary>
    /// This spawns the first tetromino to start the game.
    /// </summary>
    public static void StartGame()
    {
        SpawnManager.Instance.SpawnTetromino();
    }

    /// <summary>
    /// TODO: take care of the score here.
    /// </summary>
    public static void EndGame()
    {
        Debug.Log("Game Ended");
    }

}
