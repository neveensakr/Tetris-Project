using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Starter
{
    private static bool _isInitalized = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnSceneLoad()
    {
        if (_isInitalized)
            return;

        GameObject managerObject = new GameObject("GameManager");
        // Add the load and game managers.
        managerObject.AddComponent<LoadManager>();
        managerObject.AddComponent<EventSystem>();
        managerObject.AddComponent<StandaloneInputModule>();
        // Adding the event system.
        Object.DontDestroyOnLoad(managerObject);
        // Start the StartRoutine.
        LoadManager.Instance.StartCoroutine(LoadManager.StartRoutine());
        _isInitalized = true;
    }
}