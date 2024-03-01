using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f; // Limite de temps en secondes
    public TextMeshProUGUI timerText; // R�f�rence au TextMeshPro - Text pour afficher le temps restant

    public GameObject gameOverMenu; // R�f�rence au menu de fin de partie
    public ObjectSpawner objectSpawner; // R�f�rence au script ObjectSpawner


    private float remainingTime;
    private bool gameIsOver = false;
    private bool isTimerRunning = true;

    private void Start()
    {
        remainingTime = timeLimit;
    }

    private void Update()
    {
        if(!gameIsOver && isTimerRunning)
        {
             remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                // Le temps est �coul�, appeler la fonction pour g�rer la fin du mini-jeu
                OnTimeExpired();
                return;
            }

            // Mettre � jour le texte du timer
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
       
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    private void OnTimeExpired()
    {
         // Afficher le menu de fin de partie
        gameOverMenu.SetActive(true);
     
        // Appeler la m�thode GameOver du ObjectSpawner pour supprimer les objets
        if(objectSpawner != null)
        {
            objectSpawner.GameOver();
        }
        gameIsOver = true;
        
        // Mettre le jeu en pause
        Time.timeScale = 0f;
    }
}