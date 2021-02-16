using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; //singleton pattern
    public int highScore;

    [SerializeField] private bool useUI;
    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] private string scoreText, scoreFormat;

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

        UpdateUI();
    }

    public int Score { get; private set; } //other scripts can set value

    public void IncreaseScore(int amount) //method increases score
    {
        Score += amount;
        UpdateHighScore();
        UpdateUI();
    }

    public void UpdateHighScore() //method checks if score is greater than highscore, if so then highscore becomes equal to score and saved in playerprefs
    {
        if (Score > PlayerPrefs.GetInt("HighScore"))
        {
            highScore = Score;
        }
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void UpdateUI()
    {
        if (!useUI)
            return;

        scoreUI.text = scoreText + Score.ToString(scoreFormat);
    }

    public void ResetScore() //method resets score
    {
        Score = 0;
    }
}
