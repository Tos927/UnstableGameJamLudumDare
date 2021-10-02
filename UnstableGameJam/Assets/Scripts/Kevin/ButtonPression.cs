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
    private int timeBeforeGameOver = 3;

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
            Debug.LogError("Button Press doesn't work or isn't activated");
        }
    }

    IEnumerator limitTime()
    {
        yield return new WaitForSeconds(timeBeforeGameOver);
        if (isToActivate)
        {
            Debug.Log("u r dead lulz");
        }
        else
        {
            Debug.Log("task good!");
        }
    }
}
