using System;
using TMPro;
using UnityEngine;
using System.Collections; // Ajoutez cette ligne pour inclure le namespace System.Collections


public class ScoreManager : MonoBehaviour
{
    public static event Action<int> OnScoreChanged;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int score;
    [SerializeField] private int scoreToReach;

    public Timer timer; // Référence au script Timer

    public ObjectSpawner objectSpawner; // Référence à l'Object Spawner

    public GameObject particleEffectPrefab; // Prefab des particules à instancier
    public float returnDelay = 3f; // Délai avant de retourner à la scène précédente

    private Coroutine returnCoroutine;

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        if (score >= scoreToReach)
        {
            // Instancier les particules
            InstantiateParticleEffect();

            // Supprimer les objets instanciés par l'Object Spawner
            if (objectSpawner != null)
            {
                objectSpawner.GameOver();
            }

             // Arrêter le timer
            if (timer != null)
            {
                timer.StopTimer();
            }

            // Démarre la coroutine pour retourner à la scène précédente après un délai
            if (returnCoroutine == null)
            {
                returnCoroutine = StartCoroutine(ReturnToPreviousSceneCoroutine());
            }
        }
        OnScoreChanged?.Invoke(score);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void InstantiateParticleEffect()
    {
        if (particleEffectPrefab != null)
        {
             // Instancier les particules
            GameObject particleObject = Instantiate(particleEffectPrefab, transform.position, transform.rotation);
        
            // Accéder à la rotation du particle effect
            Quaternion rotation = particleObject.transform.rotation;
        }
    }

    private IEnumerator ReturnToPreviousSceneCoroutine()
    {
        yield return new WaitForSeconds(returnDelay);

        // Retourne à la scène précédente en utilisant le SceneTransitionManager
        SceneTransitionManager.Instance.ReturnToPreviousScene();
    }
}