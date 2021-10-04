using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField]
    private GameObject gameTimer;

    public GameObject bestScoreText;

    public string scoreText = "00:00:00";

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
        gameTimer = GameObject.Find("/Main Camera/Canvas/Timer");

        bestScoreText = GameObject.Find("/Main Camera/Canvas/Scoring");

        bestScoreText.GetComponent<Text>().text = scoreText;
    }

    public void SetBestScore()
    {
        scoreText = gameTimer.GetComponent<GameTimer>().TimerText.text;

        Debug.Log("SetBestScore");
    }

}
