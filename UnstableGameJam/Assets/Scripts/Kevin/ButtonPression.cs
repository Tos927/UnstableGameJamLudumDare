using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPression : MonoBehaviour
{
    public bool isToActivate;

    [SerializeField]
    private Sprite workingLED;
    [SerializeField]
    private Sprite errorLED;

    [SerializeField]
    private Image diod;

    [SerializeField]
    private int timeBeforeGameOver = 8;

    private AudioSource audioSource;
    public AudioClip pressed;
    //public Sprite sprite;
    //public Sprite pressedSprite;
    //Time Before death dans while
    private int i = 5;

    private void Start()
    {
        diod.sprite = workingLED;
        audioSource = GetComponent<AudioSource>();
        i = timeBeforeGameOver;

        StartCoroutine(limitTime());
    }

    void Update()
    {
        if (isToActivate)
        {
            if (diod.sprite == workingLED)
            {
                diod.sprite = errorLED;
            }
        }
    }

    public void ButtonToPress()
    {
        //this.GetComponent<Image>().sprite = pressedSprite;

        if (isToActivate && diod.sprite == errorLED)
        {
            audioSource.PlayOneShot(pressed);
            diod.sprite = workingLED;
            //this.GetComponent<Image>().sprite = sprite;
            isToActivate = false;
        }
        else
        {
            GameManager.instance.loose = true;
            Debug.Log("mort par bouton pression");
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

        Debug.Log("mort par bouton pression");
        GameManager.instance.loose = true;
        GameTimer.playing = false;
    }
}
