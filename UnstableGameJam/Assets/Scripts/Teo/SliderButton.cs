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
            StartCoroutine(limitTime());
            sliderNumber = sliderButton.value;
            randomText.text = rdmNumber.ToString();
            sliderNumberText.text = sliderNumber.ToString();
        }
        else
        {
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
            }
        }
        else
        {
            Debug.Log("Fallait pas appuyer !");
            sliderButton.value = 0;
            sliderNumberText.text = "0";
            randomText.text = "0";
        }
    }
   IEnumerator limitTime()
    {
        yield return new WaitForSeconds(3);
        if (isToActivate)
        {
            isToActivate = false;
        }
        else
        {
            Debug.Log("Gagner");
        }
    }
}
