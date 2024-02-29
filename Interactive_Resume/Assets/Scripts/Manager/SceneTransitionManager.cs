using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    private Vector3 playerPosition;

    private void Awake()
    {
        Instance = this;

        // Restaure la position du joueur s'il existe dans la sc�ne
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
        // Stocke la position du joueur s'il existe dans la sc�ne
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerPosition = playerObject.transform.position;
        }

        // Stocke le nom de la sc�ne pr�c�dente
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);

        // Stocke la position du joueur
        if (playerObject != null)
        {
            PlayerPrefs.SetFloat("PreviousPlayerPositionX", playerPosition.x);
            PlayerPrefs.SetFloat("PreviousPlayerPositionY", playerPosition.y);
            PlayerPrefs.SetFloat("PreviousPlayerPositionZ", playerPosition.z);
        }

        // Charge la nouvelle sc�ne
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToPreviousScene()
    {
        // R�cup�re le nom de la sc�ne pr�c�dente
        string previousSceneName = PlayerPrefs.GetString("PreviousScene");

        // Charge la sc�ne pr�c�dente
        SceneManager.LoadScene(previousSceneName);
    }
}