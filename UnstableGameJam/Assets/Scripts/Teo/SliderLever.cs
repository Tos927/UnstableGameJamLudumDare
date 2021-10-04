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

    public float target;
    public float max = 10;
    public float min = 0;

    public GameObject backgroudnSlider;

    public Sprite sliderAtMax;
    public Sprite sliderAtMid;
    public Sprite sliderAtMin;
    [SerializeField]
    private int timeBeforeGameOver = 8;

    //Time Before death dans while
    private int i = 5;

    private void Start()
    {
        target = max;//met la target au max
        audioSource = GetComponent<AudioSource>();
        i = timeBeforeGameOver;

        StartCoroutine(limitTime());
    }

    private AudioSource audioSource;
    public AudioClip pressed;



    
    private void Update()
    {
        sliderNumber = sliderLever.value;//attribue la valeur du slide a chaque frames

        if (isToActivate)//si il faut agir sur la task
        {
            if (led.GetComponent<Image>().sprite = greenLed)//si le sprite de la led est vert
            {
                led.GetComponent<Image>().sprite = redLed;//alors on met en rouge
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
            audioSource.PlayOneShot(pressed);
            isToActivate = false;
            Debug.Log("c'est bon?");
        }
        if (sliderNumber == max)//si le slider est deja sur la valeur la plus petite alors on luis dit d'aller sur 0
        {
            backgroudnSlider.GetComponent<Image>().sprite = sliderAtMax;
            target = min;
            Debug.Log("min min");
        }
        else if (sliderNumber == min)//si le slider est deja sur la valeur la plus grande alors on luis dit d'aller sur 10
        {
            backgroudnSlider.GetComponent<Image>().sprite = sliderAtMin;
            target = max;
            Debug.Log("max max");
        }
        if(sliderNumber == 5)
        {
            backgroudnSlider.GetComponent<Image>().sprite = sliderAtMid;
        }
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

        Debug.Log("mort par bouton slider");
        GameManager.instance.loose = true;
        GameTimer.playing = false;
    }

}
