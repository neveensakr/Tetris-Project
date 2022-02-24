using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    /// <summary>
    /// Loads the Game Scene.
    /// </summary>
    public void PlayBtn()
    {
        LoadManager.GoToGame();
    }
}
