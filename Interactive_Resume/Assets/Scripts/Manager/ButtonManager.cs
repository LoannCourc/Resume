using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void RestartScene()
    {
        // Recharge la sc�ne actuelle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Remet le temps � la normale
        Time.timeScale = 1f;
    }

    public void ReturnToPreviousScene()
    {
        // Remet le temps � la normale
        Time.timeScale = 1f;
        // Retourne � la sc�ne pr�c�dente en utilisant le SceneTransitionManager
        SceneTransitionManager.Instance.ReturnToPreviousScene();
    }
}