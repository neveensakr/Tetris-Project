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
        // The loading screen should be disabled initially as the LoadingScene is always loaded.
        DisableScreen();
    }

    /// <summary>
    /// Enables the Loading Screen.
    /// </summary>
    public void EnableScreen()
    {
        _loadingScreen.enabled = true;
    }

    /// <summary>
    /// Disables the Loading Screen.
    /// </summary>
    public void DisableScreen()
    {
        _loadingScreen.enabled = false;
    }
}

