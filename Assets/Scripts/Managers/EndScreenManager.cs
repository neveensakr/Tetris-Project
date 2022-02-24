using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenManager : MonoBehaviour
{
    /// <summary>
    /// This restarts the game
    /// </summary>
    public void RestartBtn()
    {
        LoadManager.GoToGame();
    }
}
