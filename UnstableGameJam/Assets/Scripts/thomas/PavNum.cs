using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PavNum : MonoBehaviour
{

    public int nextButton;
    public GameObject gamePanel;
    public GameObject[] myObjects;
    public bool isToActivate;
    public GameObject led;
    public Sprite redLed;
    public Sprite greenLed;
    void Start()
    {
        nextButton = 0;
        randomize();
    }
    public void randomize()
    {
        nextButton = 0;
        for (int i = 0; i < myObjects.Length; i++)
        {
            myObjects[i].transform.SetSiblingIndex(Random.Range(0, 7));
        }
    }
    public void ButtonOrder(int button)
    {
        Debug.Log("presse");
        if (isToActivate == true)
        {
            if (button == nextButton)
            {
                nextButton++;
                Debug.Log("button suivant" + nextButton);
            }
            else
            {
                nextButton = 0;
                randomize();
            }
            if (button == 7)
            {
                nextButton = 0;
                Debug.Log("taskgood");
                randomize();
                isToActivate = false;
            }
        }
        else
        {
            Debug.Log("dumb ass shit");
        }
    }
    void Update()
    {
        if (isToActivate)
        {
            if (led.GetComponent<Image>().sprite = greenLed)
            {
                led.GetComponent<Image>().sprite = redLed;
                StartCoroutine(limitTime());
                Debug.Log("led en rouge ");
            }
        }
        else
        {
            led.GetComponent<Image>().sprite = greenLed;
            Debug.Log("led en vert ");
        }
    }

    IEnumerator limitTime()
    {
        yield return new WaitForSeconds(10);
        if (isToActivate)
        {
            Debug.Log("u r dead lulz");
            GameManager.instance.loose = true;

        }
        else
        {
            Debug.Log("task good!");

        }
    }
}
