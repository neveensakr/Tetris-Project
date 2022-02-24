using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public static LoadManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public static IEnumerator StartRoutine()
    {
        // Creating the game camera.
        GameObject cameraObj = Instantiate(Resources.Load<GameObject>("GameCamera"));
        Object.DontDestroyOnLoad(cameraObj);

        yield return Instance.StartCoroutine(LoadScene("LoadingScene"));

        // initalizing audio...

        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                Instance.StartCoroutine(StartSceneRoutine());
                break;
            case "MainMenu":
                Instance.StartCoroutine(GoToMenuRoutine());
                break;
            case "EndScreen":
                Instance.StartCoroutine(GoToEndScreenRoutine());
                break;
            case "Game":
                Instance.StartCoroutine(GoToGameRoutine());
                break;
        }

        Debug.Log("Start Routine Finished");

        yield break;
    }

    public static IEnumerator StartSceneRoutine()
    {
        Debug.Log("Start Scene Initalized");

        yield break;
    }

    public static void GoToMenu()
    {
        // Load Menu Scene.
        Instance.StartCoroutine(GoToMenuRoutine());
    }

    public static IEnumerator GoToMenuRoutine()
    {
        LoadingScreenManager.Instance.EnableScreen();

        // Unload any scenes that do not need to be there.
        yield return Instance.StartCoroutine(UnloadScene("MainMenu"));
        yield return Instance.StartCoroutine(UnloadScene("Game"));
        yield return Instance.StartCoroutine(UnloadScene("EndScreen"));

        // Load Menu Scene.
        yield return Instance.StartCoroutine(LoadScene("MainMenu"));

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenu"));

        LoadingScreenManager.Instance.DisableScreen();

        Debug.Log("Menu Scene Initalized");

        yield break;
    }

    public static void GoToGame()
    {
        Instance.StartCoroutine(GoToGameRoutine());
    }

    public static IEnumerator GoToGameRoutine()
    {
        LoadingScreenManager.Instance.EnableScreen();
        
        // Unload any scenes that do not need to be there.
        yield return Instance.StartCoroutine(UnloadScene("MainMenu"));
        yield return Instance.StartCoroutine(UnloadScene("Game"));
        yield return Instance.StartCoroutine(UnloadScene("EndScreen"));

        // Load Game Scene.
        yield return Instance.StartCoroutine(LoadScene("Game"));

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));

        // Call a setup function in Game Manager.
        GameManager.StartGame();
        
        LoadingScreenManager.Instance.DisableScreen();

        Debug.Log("Game Initalized");

        yield break;
    }

    public static void GoToEndScreen()
    {
        Instance.StartCoroutine(GoToEndScreenRoutine());
    }

    public static IEnumerator GoToEndScreenRoutine()
    {
        yield return Instance.StartCoroutine(UnloadScene("EndScreen"));

        // Load EndScreen Scene.
        yield return Instance.StartCoroutine(LoadScene("EndScreen"));

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("EndScreen"));

        // Call a setup function in Game Manager.
        GameManager.EndGame();

        Debug.Log("End Screen Initalized.");

        yield break;
    }

    private static IEnumerator UnloadScene(string name)
    {
        if (SceneManager.GetSceneByName(name).isLoaded)
            yield return SceneManager.UnloadSceneAsync(name, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        yield break;
    }

    private static IEnumerator LoadScene(string name)
    {
        if (!SceneManager.GetSceneByName(name).isLoaded)
            yield return SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        yield break;
    }

}