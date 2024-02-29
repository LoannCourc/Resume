using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public float growFactor = 2f;
    public float shrinkFactor = 0.5f;

    public int scoreValue = 10;
    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void Grow()
    {
        transform.localScale *= growFactor;
    }

    public void Shrink()
    {
        transform.localScale *= shrinkFactor;
    }

    public void AddPoint()
    {
        if (scoreManager != null)
        {
            scoreManager.AddScore(scoreValue);
        }
        Debug.Log("Add Points");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
