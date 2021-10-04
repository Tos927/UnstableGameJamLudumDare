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

    private bool waitSeconds = false;
    private bool processing = false;

    

    [SerializeField]
    private int timeBeforeGameOver = 5;

    //Time Before death dans while
    private int i = 5;

    public void Start()
    {
        Debug.Log(rdmNumber);
        randomText.text = "0";

        i = timeBeforeGameOver;

        StartCoroutine(limitTime());
    }

    private void PickRandomNumber(int maxInt)
    {
        int numberToDo = Random.Range(1, maxInt + 1);
        rdmNumber = numberToDo;
    }

    public void Update()
    {
        sliderNumber = sliderButton.value;

        if (isToActivate)
        {
            if (led.GetComponent<Image>().sprite = greenLed)
            {
                led.GetComponent<Image>().sprite = redLed;

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
            Debug.Log("mort par slider bouton");
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

            if (waitSeconds)
            {
                isToActivate = false;
                waitSeconds = false;
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
        yield return new WaitForSeconds(1);

        if (sliderNumber == rdmNumber)
        {
            waitSeconds = true;
        }
        processing = false;
    }

    IEnumerator limitTime()
    {
        while (i > 0)
        {
            if (!isToActivate)
            {
                i = timeBeforeGameOver;
                yield return new WaitForSeconds(0.25f);
            }
            else
            {
                i--;
                yield return new WaitForSeconds(1);
            }
        }

        Debug.Log("mort par slider bouton");
        GameManager.instance.loose = true;
        GameTimer.playing = false;
    }
}
