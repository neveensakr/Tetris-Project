using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenManager : MonoBehaviour
{
    public void RestartBtn()
    {
        LoadManager.GoToGame();
    }
}
