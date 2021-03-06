using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _highscoreText;

    public static HudManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// This updates the score field in the HUD.
    /// </summary>
    /// <param name="score">New score</param>
    public void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    public void UpdateHighscore(int score)
    {
        _highscoreText.text = score.ToString();
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
#elif (UNITY_STANDALONE) 
         Application.Quit();
#elif (UNITY_WEBGL)
    Application.OpenURL("about:blank");
#endif
    }
}
