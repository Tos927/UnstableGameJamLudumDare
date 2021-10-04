using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    // Empty at the begenning
    [SerializeField]
    private GameObject gameTimer;
    // Empty at the begenning
    [SerializeField]
    private GameObject bestScoreText;

    //Don't change this
    public string scoreText = "00:00:00";

    public float previousScore =0f;
    public float bestScore = 0f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);

        Debug.Log("DontDestroyOnLoad");
    }

    private void Update()
    {
        
        // Fetch Timer (middle) and Scoring (top/right)
        if (gameTimer == null)
        {
            gameTimer = GameObject.Find("/Main Camera/Canvas/Timer");
        }

        if (bestScoreText == null)
        {
            bestScoreText = GameObject.Find("/Main Camera/Canvas/Scoring");
        }

        if (bestScoreText.GetComponent<Text>().text != scoreText)
        {
            bestScoreText.GetComponent<Text>().text = scoreText;
        }
    }

    public void SetBestScore()
    {
        previousScore = gameTimer.GetComponent<GameTimer>().score;

        if (previousScore > bestScore)
        {
            scoreText = gameTimer.GetComponent<GameTimer>().TimerText.text;
            bestScore = previousScore;
        }
    }

}
