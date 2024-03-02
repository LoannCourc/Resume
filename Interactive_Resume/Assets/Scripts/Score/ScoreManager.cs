using System;
using TMPro;
using UnityEngine;
using System.Collections; // Ajoutez cette ligne pour inclure le namespace System.Collections


public class ScoreManager : MonoBehaviour
{
    public static event Action<int> OnScoreChanged;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreToReachText;
    [SerializeField] private int score;
    [SerializeField] private int scoreToReach;

    public Timer timer; // R�f�rence au script Timer

    public ObjectSpawner objectSpawner; // R�f�rence � l'Object Spawner
    public Transform particleSpawnPoint; // Assignez le GameObject vide dans l'�diteur Unity

    public GameObject particleEffectPrefab; // Prefab des particules � instancier
    
    public GameObject canvasUi;
    public float returnDelay = 3f; // D�lai avant de retourner � la sc�ne pr�c�dente

    private Coroutine returnCoroutine;

    private void Start()
    {
        scoreToReachText.text = "Score to reach: " + scoreToReach;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        if (score >= scoreToReach)
        {
            // Instancier les particules
            InstantiateParticleEffect();

            // Supprimer les objets instanci�s par l'Object Spawner
            if (objectSpawner != null)
            {
                objectSpawner.GameOver();
            }

             // Arr�ter le timer
            if (timer != null)
            {
                timer.StopTimer();
            }

            if(canvasUi != null){
                canvasUi.SetActive(false);
            }

            // D�marre la coroutine pour retourner � la sc�ne pr�c�dente apr�s un d�lai
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
        if (particleEffectPrefab != null && particleSpawnPoint != null)
        {
             // Instancier les particules � la position et rotation du spawnPoint
            Instantiate(particleEffectPrefab, particleSpawnPoint.position, particleSpawnPoint.rotation);
        }
    }

    private IEnumerator ReturnToPreviousSceneCoroutine()
    {
        yield return new WaitForSeconds(returnDelay);

        // Retourne � la sc�ne pr�c�dente en utilisant le SceneTransitionManager
        SceneTransitionManager.Instance.ReturnToPreviousScene();
    }
}