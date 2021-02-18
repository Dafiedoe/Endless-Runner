using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    private bool isGameOver = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (isGameOver) return;

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
        ObstacleSpawner.instance.CallDifficultyIncrease(increaseSpeed);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
