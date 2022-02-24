using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenManager : MonoBehaviour
{
    public static LoadingScreenManager Instance;

    [SerializeField] private Canvas _loadingScreen;

    private void Awake()
    {
        Instance = this;
        DisableScreen();
    }

    public void EnableScreen()
    {
        _loadingScreen.enabled = true;
    }

    public void DisableScreen()
    {
        _loadingScreen.enabled = false;
    }
}

