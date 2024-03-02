using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondGameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score : " + score;
    }
}
