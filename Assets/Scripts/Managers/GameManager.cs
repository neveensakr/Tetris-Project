using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameOver { get; private set;  }
    private static int _score;
    private static int _highscore = 0;

    /// <summary>
    /// This sets the highscore value in the PlayerPrefs and updates the HUD.
    /// </summary>
    /// <param name="newValue">New Highscore</param>
    private static void SetHighscore(int newValue)
    {
        _highscore = newValue;
        PlayerPrefs.SetInt("highscore", _highscore);
        PlayerPrefs.Save();
        HudManager.Instance.UpdateHighscore(_highscore);
    }

    /// <summary>
    /// This returns the current highscore in PlayerPrefs.
    /// </summary>
    private static int GetHighscore()
    {
        return PlayerPrefs.GetInt("highscore");
    }

    /// <summary>
    /// This function is called when the game is over.
    /// It pauses the game and Loads the End screen.
    /// </summary>
    public static void GameEnded()
    {
        GameOver = true;
        Time.timeScale = 0;
        LoadManager.GoToEndScreen();
        if (_score > _highscore)
            SetHighscore(_score);
        SpawnManager.Instance.CancelInvoke(); // Stop spawning blocker blocks.
    }

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
        // Reset values.
        Time.timeScale = 1;
        GameOver = false;
        _score = 0;
        _highscore = GetHighscore();
        HudManager.Instance.UpdateHighscore(_highscore); // Updates the highscore in the HUD.
    }

}
