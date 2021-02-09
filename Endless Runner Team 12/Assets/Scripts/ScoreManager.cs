using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; //singleton pattern
    public int highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
    }

    public int Score { get; private set; } //other scripts can set value

    public void IncreaseScore(int amount) //method increases score
    {
        Score += amount;
        UpdateHighScore();

    }

    public void UpdateHighScore() //method checks if score is greater than highscore, if so then highscore becomes equal to score and saved in playerprefs
    {
        if (Score > highScore)
        {
            highScore = Score;
        }
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void ResetScore() //method resets score
    {
        Score = 0;
    }
}
