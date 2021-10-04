using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPression : MonoBehaviour
{
    public bool isToActivate;

    [SerializeField]
    private Sprite workingLED;
    [SerializeField]
    private Sprite errorLED;

    [SerializeField]
    private Image diod;

    [SerializeField]
    private int timeBeforeGameOver = 5;

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

                StartCoroutine(limitTime());
            }
        }
    }

    public void ButtonToPress()
    {
        if (isToActivate && diod.sprite == errorLED)
        {

            diod.sprite = workingLED;

            isToActivate = false;
        }
        else
        {
            GameManager.instance.loose = true;
            Debug.Log("mort par boutton pression");
        }
    }

    IEnumerator limitTime()
    {
        yield return new WaitForSeconds(timeBeforeGameOver);
        if (isToActivate)
        {
            Debug.Log("mort par boutton pression");
            GameManager.instance.loose = true;
            GameTimer.playing = false;
        }
        else
        {
            Debug.Log("task good!");
        }
    }
}
