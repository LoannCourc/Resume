using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f; // Limite de temps en secondes
    public TextMeshProUGUI timerText; // R�f�rence au TextMeshPro - Text pour afficher le temps restant

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
            // Le temps est �coul�, appeler la fonction pour g�rer la fin du mini-jeu
            OnTimeExpired();
            return;
        }

        // Mettre � jour le texte du timer
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnTimeExpired()
    {
        // Appeler la fonction pour g�rer la fin du mini-jeu lorsque le temps est �coul�
        Debug.Log("Temps �coul� !");
    }
}