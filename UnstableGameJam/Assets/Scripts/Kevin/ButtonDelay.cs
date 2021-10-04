using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    public bool isToActivate;

    [SerializeField]
    private Sprite workingLED;
    [SerializeField]
    private Sprite errorLED;
    [SerializeField]
    private Sprite waitingDiode;

    [SerializeField]
    private Image diod;

    [SerializeField]
    private int timeBeforeGameOver = 15;

    private bool isActive = false;

    private bool secondPress = false;

    private void Start()
    {
        diod.sprite = workingLED;
    }

    void Update()
    {
        if (isToActivate)
        {
            if(diod.sprite == workingLED)
            {
                diod.sprite = errorLED;

                StartCoroutine(limitTime());
            }
        }
    }

    public void ButtonToPress2Times()
    {
        if (isToActivate)
        {
            if (!isActive && (diod.sprite == errorLED || diod.sprite == waitingDiode))
            {
                isActive = true;
                StartCoroutine(Press2Times());
            }
        }
        else   
        {
            GameManager.instance.loose = true;
            Debug.Log("mort par bouton delay");
        }
    }

    IEnumerator Press2Times()
    {
        if (secondPress)
        {
            diod.sprite = workingLED;
            secondPress = false;

            isActive = false;
            isToActivate = false;
        }
        else
        {
            diod.sprite = waitingDiode;
            yield return new WaitForSeconds(5f);
            diod.sprite = errorLED;
            secondPress = true;

            isActive = false;
        }
    }

    IEnumerator limitTime()
    {
        yield return new WaitForSeconds(timeBeforeGameOver);
        if (isToActivate)
        {
            Debug.Log("mort par bouton delay");
            GameManager.instance.loose = true;
            GameTimer.playing = false;
        }
        else
        {
            Debug.Log("task good!");
        }
    }
}
