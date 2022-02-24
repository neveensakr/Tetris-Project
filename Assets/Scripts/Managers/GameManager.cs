using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    /// <summary>
    /// This restarts the game.
    /// </summary>
    public void RestartBtn()
    {
        LoadManager.GoToGame();
    }

    /// <summary>
    /// This pauses the game depending on the pause value.
    /// </summary>
    /// <param name="pause">Should the game be paused?</param>
    public void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }

    /// <summary>
    /// This quits the game in both the editor and the application (when built).
    /// </summary>
    public void QuitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
