using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderButton : MonoBehaviour
{
    public bool isToActivate;
    public Slider sliderButton;

    public int rdmNumber;
    public float sliderNumber;

    //public int needingTime = 2;
    //public int timePassed = 0;

    public Text sliderNumberText;
    public Text randomText;
    public GameObject led;
    public Sprite greenLed;
    public Sprite redLed;

    private void PickRandomNumbe(int maxInt)
    {
        int numberToDo = Random.Range(1, maxInt + 1);
        rdmNumber = numberToDo;
    }

    public void Start()
    {
        PickRandomNumbe(10);
        Debug.Log(rdmNumber);
        randomText.text = "0";
    }

    public void Update()
    {
        sliderNumber = sliderButton.value;

        if (isToActivate)
        {
            if (led.GetComponent<Image>().sprite = greenLed)
            {
                led.GetComponent<Image>().sprite = redLed;
                StartCoroutine(limitTime());
                randomText.text = rdmNumber.ToString();
                sliderNumberText.text = sliderNumber.ToString();
            }
            activation();
        }
        else if (!isToActivate && sliderNumber != rdmNumber && sliderNumber != 0)
        {
            Debug.Log("mort");
            isToActivate = false;
        }
        else
        {
            led.GetComponent<Image>().sprite = greenLed;
            sliderNumberText.text = "0";
            randomText.text = "0";
        }
    }
    public void activation()
    {
        //StartCoroutine(checkTime());
        if (sliderNumber == rdmNumber) //&& timePassed == needingTime)
        {
            isToActivate = false;
            Debug.Log("Gagner !");
        }
    }
    /*IEnumerator checkTime()
    {
        yield return new WaitForSeconds(2);
        timePassed = 2;

    }*/
    IEnumerator limitTime()
    {
        yield return new WaitForSeconds(3);
        if (isToActivate)
        {
            Debug.Log("u r dead lulz");
            isToActivate = false;
            sliderButton.value = 0;
        }
        else
        {
            Debug.Log("task good");
            sliderButton.value = 0;
        }

    }

}
