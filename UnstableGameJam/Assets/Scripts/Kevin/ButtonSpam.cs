using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpam : MonoBehaviour
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
    //Time Before death dans while
    private int i = 4;

    private void Start()
    {
        diod.sprite = workingLED;
        audioSource=GetComponent<AudioSource>();
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
                spamNumbers = 5;
            }
        }
    }

    private int spamNumbers = 5;
    public void ButtonToSpam()
    {
        audioSource.PlayOneShot(pressed);
        if (isToActivate)
        {
            spamNumbers--;

            if (spamNumbers == 0)
            {
                diod.sprite = workingLED;
                isToActivate = false;
            }
        }
        else
        {
            Debug.Log("mort par bouton spam");
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

        Debug.Log("mort par bouton spam");
        GameManager.instance.loose = true;
        GameTimer.playing = false;
    }

    /*IEnumerator limitTime()
    {
        yield return new WaitForSeconds(timeBeforeGameOver);
        if (isToActivate)
        {
            Debug.Log("mort par boutton spam");
            GameManager.instance.loose = true;
            GameTimer.playing = false;
        }
        else
        {
            Debug.Log("task good!");
        }
    }*/
}
