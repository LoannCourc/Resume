using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f; // Limite de temps en secondes
    public TextMeshProUGUI timerText; // Référence au TextMeshPro - Text pour afficher le temps restant

    private float remainingTime;

    private void Start()
    {
        remainingTime = timeLimit;
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            // Le temps est écoulé, appeler la fonction pour gérer la fin du mini-jeu
            OnTimeExpired();
            return;
        }

        // Mettre à jour le texte du timer
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnTimeExpired()
    {
        // Appeler la fonction pour gérer la fin du mini-jeu lorsque le temps est écoulé
        Debug.Log("Temps écoulé !");
    }
}