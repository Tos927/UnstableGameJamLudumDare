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

    private void PickRandomNumbe(int maxInt)
    {
        int numberToDo = Random.Range(1, maxInt + 1);
        rdmNumber = numberToDo;
    }

    public void Start()
    {
        PickRandomNumbe(10);
        Debug.Log(rdmNumber);
        randomText.text = rdmNumber.ToString();
    }

    public void Update()
    {
        if (isToActivate)
        {
            led.GetComponent<Image>().sprite = redLed;
            StartCoroutine(limitTime());
            sliderNumber = sliderButton.value;
            randomText.text = rdmNumber.ToString();
            sliderNumberText.text = sliderNumber.ToString();
        }
        else
        {
            led.GetComponent<Image>().sprite = greenLed;
            sliderButton.value = 0;
            sliderNumberText.text = "0";
            randomText.text = "0";
        }
    }
    public void Activation()
    {
        if (isToActivate)
        {
            if (sliderNumber == rdmNumber)
            {
                Debug.Log("Gagner !");
                this.GetComponent<Slider>().enabled = false;

            }
        }
        else
        {
            Debug.Log("Fallait pas appuyer !");
        }
    }
   IEnumerator limitTime()
    {
        yield return new WaitForSeconds(3);
        if (isToActivate)
        {
            isToActivate = false;
            //Destroy(this);
        }
        else
        {
            Debug.Log("Gagner");
        }
        //this.GetComponent<Slider>().enabled = true;
    }
}
