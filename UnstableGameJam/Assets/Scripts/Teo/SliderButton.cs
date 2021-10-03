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

    public Text sliderNumberText;
    public Text randomText;
    public GameObject led;
    public Sprite greenLed;
    public Sprite redLed;

    private bool wait2Seconds = false;
    private bool processing = false;

    private void PickRandomNumber(int maxInt)
    {
        int numberToDo = Random.Range(1, maxInt + 1);
        rdmNumber = numberToDo;
    }

    public void Start()
    {
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
            if (rdmNumber == 0)
            {
                PickRandomNumber(10);
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

        if (sliderNumber == rdmNumber)
        {
            if (!processing)
            {
                StartCoroutine(checkTime());
            }

            if (wait2Seconds)
            {
                isToActivate = false;
                wait2Seconds = false;
                processing = false;
                sliderButton.value = 0;
                rdmNumber = 0;
                Debug.Log("Gagner !");
            }
        }
    }
    IEnumerator checkTime()
    {
        processing = true;
        yield return new WaitForSeconds(2);

        if (sliderNumber == rdmNumber)
        {
            wait2Seconds = true;
        }
        processing = false;
    }
    IEnumerator limitTime()
    {
        yield return new WaitForSeconds(6);
        if (isToActivate)
        {
            Debug.Log("u r dead lulz");
        }
        else
        {
            Debug.Log("task good");
            if (sliderButton.value != 0)
            {
                sliderButton.value = 0;
            }
        }
    }
}
