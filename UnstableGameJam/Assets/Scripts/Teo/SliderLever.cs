using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderLever : MonoBehaviour
{
    public bool isToActivate;
    public Slider sliderLever;
    public float sliderNumber ;

    public GameObject led;
    public Sprite greenLed;
    public Sprite redLed;

    public float target;
    public float max = 10;
    public float min = 0;

    public int timeBeforeGameOver = 20;
    // Je sais pas trop ce qui ne va pas, mais de ce qui va:
    // quand !isToActivate le slider ne bouge paset renvoit "Fallait pas appuyer !",
    // la led s'active quand isToActivate l'est et se desactive quand il ne l'est plus.
    // Mais je sais pas pourquoi le if (sliderNumber == maxToReach) à des problèmes.

    private void Start()
    {
            target = max;//met la target au max

    }

    private void Update()
    {
        sliderNumber = sliderLever.value;//attribue la valeur du slide a chaque frames

        if (isToActivate)//si il faut agir sur la task
        {
            if (led.GetComponent<Image>().sprite = greenLed)//si le sprite de la led est vert
            {
                led.GetComponent<Image>().sprite = redLed;//alors on met en rouge
                StartCoroutine(limitTime());//et on lance la couroutine
                
            }
            slidercount();//a chaque frame on lance la fonction qui check la veleur du slider
        }
        else if (!isToActivate && sliderNumber != max && sliderNumber != min)//si le joueur bouge le slider alors qu'il ne doit pas alors il perd
        {
            GameManager.instance.loose = true;
            Debug.Log("mort par slider lever");
        }
        else//sinon la led est verte
        {
            led.GetComponent<Image>().sprite = greenLed;
        }
        
    }
    public void slidercount()
    {
        if (sliderNumber == target)//si la valeur du slider est égal a la target alors c'est bon 
        {
            isToActivate = false;
            Debug.Log("c'est bon?");
        }
        if (sliderNumber == max)//si le slider est deja sur la valeur la plus petite alors on luis dit d'aller sur 0
        {
            target = min;
            Debug.Log("min min");
        }
        else if (sliderNumber == min)//si le slider est deja sur la valeur la plus grande alors on luis dit d'aller sur 10
        {
            target = max;
            Debug.Log("max max");
        }
        
    }
    IEnumerator limitTime()
    {
        yield return new WaitForSeconds(timeBeforeGameOver);
        if (isToActivate)
        {
            GameManager.instance.loose = true;
            Debug.Log("mort par slider lever");
        }
        else
        {
            Debug.Log("task good");
        }
       
    }
    
}
