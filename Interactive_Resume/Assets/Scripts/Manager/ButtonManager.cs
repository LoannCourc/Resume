using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void RestartScene()
    {
        // Recharge la scène actuelle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Remet le temps à la normale
        Time.timeScale = 1f;
    }

    public void ReturnToPreviousScene()
    {
        // Remet le temps à la normale
        Time.timeScale = 1f;
        // Retourne à la scène précédente en utilisant le SceneTransitionManager
        SceneTransitionManager.Instance.ReturnToPreviousScene();
    }
}