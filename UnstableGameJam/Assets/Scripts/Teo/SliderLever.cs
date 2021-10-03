using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderLever : MonoBehaviour
{
    public bool isToActivate;
    public Slider sliderLever;
    public float sliderNumber;

    public GameObject led;
    public Sprite greenLed;
    public Sprite redLed;

    public float maxToReach = 10;

    void Update()
    {
        if (isToActivate)
        {
            led.GetComponent<Image>().sprite = redLed;
            sliderNumber = sliderLever.value;
            StartCoroutine(limitTime());
        }
        else
        {
            led.GetComponent<Image>().sprite = greenLed;
        }
    }

    public void Activation()
    {
        if (isToActivate && sliderNumber == maxToReach)
        {
            Debug.Log("Well done");
            isToActivate = false;
        }
        else
        {
            Debug.Log("Fallait pas appuyer !");
            sliderLever.value = 0;
        }
    }

    IEnumerator limitTime()
    {
        yield return new WaitForSeconds(3);
        if (isToActivate)
        {
            Debug.Log("u r dead lulz");
            isToActivate = false;
            sliderLever.value = 0;
        }
        else
        {
            Debug.Log("task good!");
        }
    }

}
