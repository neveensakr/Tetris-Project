using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Starter
{
    private static bool _isInitalized = false;

    /// <summary>
    /// This method runs on the first scene load.
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnSceneLoad()
    {
        if (_isInitalized)
            return;

        GameObject managerObject = new GameObject("GameManager");
        // Add the load manager.
        managerObject.AddComponent<LoadManager>();
        // Adding the event system.
        managerObject.AddComponent<EventSystem>();
        managerObject.AddComponent<StandaloneInputModule>();
        Object.DontDestroyOnLoad(managerObject);
        // Start the StartRoutine.
        LoadManager.Instance.StartCoroutine(LoadManager.StartRoutine());
        _isInitalized = true;
    }
}