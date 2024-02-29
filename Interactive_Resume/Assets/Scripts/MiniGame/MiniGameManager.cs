using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public Dictionary<string, string> miniGames = new Dictionary<string, string>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadMiniGame(string miniGameKey)
    {
        if (miniGames.TryGetValue(miniGameKey, out string sceneName))
        {
            StartCoroutine(LoadMiniGameAsync(sceneName));
        }
        else
        {
            Debug.LogError($"No mini-game found with key '{miniGameKey}'.");
        }
    }

    public void UnloadMiniGame(string sceneName)
    {
        StartCoroutine(UnloadMiniGameAsync(sceneName));
    }

    private IEnumerator LoadMiniGameAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    private IEnumerator UnloadMiniGameAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
