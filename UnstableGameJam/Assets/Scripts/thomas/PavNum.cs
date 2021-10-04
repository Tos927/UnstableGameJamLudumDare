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

    public AudioClip presseSound;
    public AudioClip fail;
    private AudioSource audioSource;


    [SerializeField]
    private int timeBeforeGameOver = 15;

    //Time Before death dans while
    private int i = 10;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        nextButton = 0;
        randomize();

        i = timeBeforeGameOver;

        StartCoroutine(limitTime());
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
                audioSource.PlayOneShot(presseSound);
            }
            else
            {
                nextButton = 0;
                audioSource.PlayOneShot(fail);
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
            GameManager.instance.loose = true;
            Debug.Log("mort par Pavé Numérique");
        }
    }
    void Update()
    {
        if (isToActivate)
        {
            if (led.GetComponent<Image>().sprite = greenLed)
            {
                led.GetComponent<Image>().sprite = redLed;
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

        Debug.Log("mort par bouton Pavé Numérique");
        GameManager.instance.loose = true;
        GameTimer.playing = false;
    }
}
