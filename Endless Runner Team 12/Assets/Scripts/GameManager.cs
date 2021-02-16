using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int scoreToAdd;
    [SerializeField] private float secondsPerScore;
    private float scoreTime;

    private void Update()
    {
        scoreTime += Time.deltaTime;
        if (scoreTime >= secondsPerScore)
        {
            ScoreManager.instance.IncreaseScore(scoreToAdd);
            scoreTime = 0f;
        }
    }
}
