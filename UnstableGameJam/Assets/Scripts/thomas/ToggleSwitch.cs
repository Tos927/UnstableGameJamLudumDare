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


    void Start()
    {
        
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
            Debug.Log("l________________________________o__________________________l");
        }
    }
    IEnumerator limitTime()
    {
        yield return new WaitForSeconds(3);
        if (isToActivate)
        {
            Debug.Log("u r dead lulz");
            //isToActivate = false;
            Destroy(this);
            //this.enabled = false;

        }
        else
        {
            Debug.Log("task good!");
            
        }
    }



}
