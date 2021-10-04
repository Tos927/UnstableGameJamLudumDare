using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ToggleSwitch : MonoBehaviour
{

    public bool isToActivate;
    public int switchState = 1;
    public GameObject switchBtn;
    public Sprite pressed1;
    public GameObject led;
    public Sprite redLed;
    public Sprite greenLed;
<<<<<<< HEAD
    public int timeBeforeGameOver = 20;
=======

    [SerializeField]
    private int timeBeforeGameOver = 5;

    //Time Before death dans while
    private int i = 5;
>>>>>>> kevin/testGameplay

    void Start()
    {
        i = timeBeforeGameOver;

        StartCoroutine(limitTime());
    }

    void Update()
    {
        if (isToActivate)
        {
            if (led.GetComponent<Image>().sprite = greenLed)
            {
                led.GetComponent<Image>().sprite = redLed;
                Debug.Log("led en rouge ");
            }
        }
        else
        {
            led.GetComponent<Image>().sprite = greenLed;
            Debug.Log("led en vert ");
        }
    }
    public void onSwitchButtonClicked()
    {
        if (isToActivate)
        {
            if (switchState == 1)
                    {
                        switchState =2;
                        Debug.Log("switch state est égale a 2");
                        switchBtn.GetComponent<Image>().sprite = pressed1;
                        isToActivate = false;
                    }
                    else
                    {
                        switchState = 1;
                        Debug.Log("switch state est égale a 1");
                        switchBtn.GetComponent<Image>().sprite = null;
                        isToActivate = false;
                    }
        }
        else
        {
            GameManager.instance.loose = true;
            Debug.Log("mort par switch");
        }
    }
    IEnumerator limitTime()
    {
<<<<<<< HEAD
        yield return new WaitForSeconds(timeBeforeGameOver);
        if (isToActivate)
=======
        while (i > 0)
>>>>>>> kevin/testGameplay
        {
            if (!isToActivate)
            {
                i = timeBeforeGameOver;
                yield return new WaitForSeconds(GameManager.instance.CheckingTimeSpeed);
            }
            else
            {
                i--;
                yield return new WaitForSeconds(1);
            }
        }

        Debug.Log("mort par bouton toggle twitch");
        GameManager.instance.loose = true;
        GameTimer.playing = false;
    }
}
