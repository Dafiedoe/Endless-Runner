using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Score over Time")]
    [SerializeField] private int scoreToAdd;
    [SerializeField] private float secondsPerScore;
    private float scoreTime;

    [Header("Difficulty Increase")]
    [SerializeField] private bool useDifficulty;
    [SerializeField] private float increaseSeconds;
    [SerializeField] private float diffIncreaseTime;
    [SerializeField] private float increaseSpeed;
    [SerializeField] private float increaseObstacleSpawnRate;

    private void Update()
    {
        scoreTime += Time.deltaTime;
        if (scoreTime >= secondsPerScore)
        {
            ScoreManager.instance.IncreaseScore(scoreToAdd);
            scoreTime = 0f;
        }

        if (useDifficulty)
        {
            diffIncreaseTime += Time.deltaTime;
            if (diffIncreaseTime >= increaseSeconds)
            {
                IncreaseDifficulty();
                diffIncreaseTime = 0f;
            }
        }
    }

    void IncreaseDifficulty()
    {
        CilinderManager.instance.CallDifficultyEvent(increaseSpeed);
        ObstacleSpawner.instance.timeClamp -= new Vector2(increaseObstacleSpawnRate, increaseObstacleSpawnRate);
    }
}
