using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static event Action<int> OnScoreChanged;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int score;

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        if (score >= 5)
        {
            // Retourne à la scène précédente en utilisant le SceneTransitionManager
            SceneTransitionManager.Instance.ReturnToPreviousScene();
        }
        OnScoreChanged?.Invoke(score);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}