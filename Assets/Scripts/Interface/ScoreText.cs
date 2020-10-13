using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private TextMeshProUGUI Stars;
    [SerializeField] private TextMeshProUGUI HighScore;

    [SerializeField] private TextMeshProUGUI starsCollected;
    [SerializeField] private TextMeshProUGUI deathScore;


    private float scoreValue;
    private float highScoreValue;
    private int starsValue;
    private int starsCollectedOnGame;

	void Awake()
	{
        if(PlayerPrefs.HasKey("HighScore"))
		{
            highScoreValue = PlayerPrefs.GetInt("HighScore");
            HighScore.text = "High Score: " + highScoreValue;
        }

        if(PlayerPrefs.HasKey("StarsCount"))
		{
            starsValue = PlayerPrefs.GetInt("StarsCount");
            Stars.text = "" + starsValue;
		}
    }

	void Update()
    {
        ScoreUpdate();
    }

    void ScoreUpdate()
	{
        scoreValue += Time.deltaTime;
        HighestScore();
        Score.text = "Score: " + Mathf.FloorToInt(scoreValue);
        deathScore.text = Score.text;
        Stars.text = "" + starsValue;
    }

    void HighestScore()
	{
        if(scoreValue > highScoreValue)
		{
            highScoreValue = scoreValue;
            HighScore.text = "High Score: " + Mathf.FloorToInt(highScoreValue);

            PlayerPrefs.SetInt("HighScore", Convert.ToInt32(highScoreValue));
		}            
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Star")
		{
            if(BuffInfluence.isDoubled)
			{
                starsValue++;
                starsCollectedOnGame++;
			}
            starsValue++;
            starsCollectedOnGame++;

            starsCollected.text = "Collected stars: " + starsCollectedOnGame;
            PlayerPrefs.SetInt("StarsCount", starsValue);
		}

        if (collision.gameObject.tag == "SpeedBuff")
        {
            StartCoroutine(SpeedUp());
        }
    }

    IEnumerator SpeedUp()
	{
        Time.timeScale = 2f;
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
	}
}
