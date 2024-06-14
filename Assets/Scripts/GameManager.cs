using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    public int score;

    public Text scoreText;
    public Text previousScoreText;
    public Playermove playermove;

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.HasKey("PreviousScore"))
        {
            int previousScore = PlayerPrefs.GetInt("PreviousScore");
            previousScoreText.text = "Previous Score: " + previousScore;
        }
        else
        {
            previousScoreText.text = "Previous Score: N/A";
        }
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        playermove.speed += playermove.speedIncreasePoint;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("PreviousScore", score);
        PlayerPrefs.Save();
    }
}
