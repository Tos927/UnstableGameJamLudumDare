using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpam : MonoBehaviour
{
    public bool isToActivate;

    [SerializeField]
    private Sprite workingLED;
    [SerializeField]
    private Sprite errorLED;

    [SerializeField]
    private Image diod;

    
    public int timeBeforeGameOver = 10;

    private void Start()
    {
        diod.sprite = workingLED;
    }

    void Update()
    {
        if (isToActivate)
        {
            if (diod.sprite == workingLED)
            {
                diod.sprite = errorLED;
                spamNumbers = 5;

                StartCoroutine(limitTime());
            }
        }
    }

    private int spamNumbers = 5;
    public void ButtonToSpam()
    {
        if (isToActivate)
        {
            spamNumbers--;

            if (spamNumbers == 0)
            {
                diod.sprite = workingLED;
                isToActivate = false;
            }
        }
        else
        {
            Debug.Log("mort par boutton spam");
        }
    }

    IEnumerator limitTime()
    {
        yield return new WaitForSeconds(timeBeforeGameOver);
        if (isToActivate)
        {
            Debug.Log("mort par boutton spam");
            GameManager.instance.loose = true;
            GameTimer.playing = false;
        }
        else
        {
            Debug.Log("task good!");
        }
    }
}
