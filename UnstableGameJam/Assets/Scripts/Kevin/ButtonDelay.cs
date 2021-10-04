using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    public bool isToActivate;

    [SerializeField]
    private Sprite workingLED;
    [SerializeField]
    private Sprite errorLED;
    [SerializeField]
    private Sprite waitingDiode;

    [SerializeField]
    private Image diod;

    private bool isActive = false;

    private bool secondPress = false;

    [SerializeField]
    private int timeBeforeGameOver = 15;

    private int i = 11;

    private AudioSource audioSource;
    public AudioClip pressed;
    //public AudioClip wait;
    public AudioClip canBePressedAgain;

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

    public void ButtonToPress2Times()
    {
        if (isToActivate)
        {
            if (!isActive && (diod.sprite == errorLED || diod.sprite == waitingDiode))
            {
                isActive = true;
                audioSource.PlayOneShot(pressed);
                StartCoroutine(Press2Times());
            }
        }
        else
        {
            GameManager.instance.loose = true;
            Debug.Log("mort par bouton delay");
        }
    }

    IEnumerator Press2Times()
    {
        if (secondPress)
        {
            diod.sprite = workingLED;
            secondPress = false;

            isActive = false;
            isToActivate = false;
            
            
            
        }
        else
        {
            diod.sprite = waitingDiode;
            yield return new WaitForSeconds(5f);
            diod.sprite = errorLED;
            secondPress = true;
            audioSource.PlayOneShot(canBePressedAgain);
            isActive = false;
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

        Debug.Log("mort par bouton delay");
        GameManager.instance.loose = true;
        GameTimer.playing = false;
    }
}
