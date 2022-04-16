using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Score : MonoBehaviour
{

    private float currentSocre = 0f;
    // Start is called before the first frame update
    public event Action onScoreUpdated;
    void Start()
    {
        onScoreUpdated?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetScore()
    {
        return currentSocre;
    }

    public void AddScore (float scoreToAdd)
    {
       currentSocre += scoreToAdd;
       onScoreUpdated?.Invoke();
    }
}
