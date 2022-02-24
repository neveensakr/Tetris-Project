using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static void StartGame()
    {
        SpawnManager.Instance.SpawnTetromino();
    }

    public static void EndGame()
    {
        Debug.Log("Game Ended");
    }

    public void RestartBtn()
    {
        LoadManager.GoToGame();
    }

    public void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }

    public void QuitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
