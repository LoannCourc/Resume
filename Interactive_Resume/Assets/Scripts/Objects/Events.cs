using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public float growFactor = 2f;
    public float shrinkFactor = 0.5f;

    public void Grow()
    {
        transform.localScale *= growFactor;
    }

    public void Shrink()
    {
        transform.localScale *= shrinkFactor;
    }
}
