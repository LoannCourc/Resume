using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    private Vector3 playerPosition;

    private void Awake()
    {
        Instance = this;

        // Restaure la position du joueur s'il existe dans la scène
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            float x = PlayerPrefs.GetFloat("PreviousPlayerPositionX");
            float y = PlayerPrefs.GetFloat("PreviousPlayerPositionY");
            float z = PlayerPrefs.GetFloat("PreviousPlayerPositionZ");

            playerObject.transform.position = new Vector3(x, y, z);
        }
    }

    public void ChangeScene(string sceneName)
    {
        // Stocke la position du joueur s'il existe dans la scène
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerPosition = playerObject.transform.position;
        }

        // Stocke le nom de la scène précédente
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);

        // Stocke la position du joueur
        if (playerObject != null)
        {
            PlayerPrefs.SetFloat("PreviousPlayerPositionX", playerPosition.x);
            PlayerPrefs.SetFloat("PreviousPlayerPositionY", playerPosition.y);
            PlayerPrefs.SetFloat("PreviousPlayerPositionZ", playerPosition.z);
        }

        // Charge la nouvelle scène
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToPreviousScene()
    {
        // Récupère le nom de la scène précédente
        string previousSceneName = PlayerPrefs.GetString("PreviousScene");

        // Charge la scène précédente
        SceneManager.LoadScene(previousSceneName);
    }
}