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

    // Je sais pas trop ce qui ne va pas, mais de ce qui va:
    // quand !isToActivate le slider ne bouge paset renvoit "Fallait pas appuyer !",
    // la led s'active quand isToActivate l'est et se desactive quand il ne l'est plus.
    // Mais je sais pas pourquoi le if (sliderNumber == maxToReach) à des problèmes.

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
        if (isToActivate)
        {
            if (sliderNumber == maxToReach)
            {
                Debug.Log("Well done");
                isToActivate = false;
                //maxToReach = 0;
            }
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
            //maxToReach = Mathf.Abs(maxToReach - 10);
            isToActivate = false;
            //sliderLever.value = 0;
        }
        else
        {
            //Debug.Log("task good!");
        }
    }
}
