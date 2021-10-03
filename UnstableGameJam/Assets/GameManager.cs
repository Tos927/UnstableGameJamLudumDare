using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverScreen;



    public static GameManager instance;
    public GameObject pressButton;
    public GameObject spamPressButton;
    public GameObject twoPressButton;
    public GameObject pavNumerique;
    public GameObject switchPress;
    public GameObject sliderOnNumber;
    public GameObject sliderlever;

    

    public bool[] tabl;
    public int randomIndex;
    public bool ischoosin;
    public bool boll;
    public bool loose;
    void Start()
    {
        
        if (instance != null)
        {
            Debug.Log("il y a plus de une instance de Game manager");
            return;

        }

        instance = this;
    }

    void Update()
    {
        if (!ischoosin)
        {
            StartCoroutine(randtest());

            switch (randomIndex)
            {
                case 0:
                    pressButton.GetComponent<ButtonPression>().isToActivate = true;
                    break;
                case 1:
                    spamPressButton.GetComponent<ButtonSpam>().isToActivate = true;
                    break;
                case 2:
                    twoPressButton.GetComponent<ButtonDelay>().isToActivate = true;
                    break;
                case 3:
                    pavNumerique.GetComponent<PavNum>().isToActivate = true;
                    break;
                case 4:
                    switchPress.GetComponent<ToggleSwitch>().isToActivate = true;
                    break;
                case 5:
                    sliderOnNumber.GetComponent<SliderButton>().isToActivate = true;
                    break;
                case 6:
                    sliderlever.GetComponent<SliderLever>().isToActivate = true;
                    break;
                default:
                    Debug.Log("pas d'autre rand");
                    break;
            }
        }
        if(loose)
        {
            gameOverScreen.SetActive(true);
            Debug.Log("perdu__________________");
        }
    }
    IEnumerator randtest()
    {
        ischoosin = true;
        yield return new WaitForSeconds(3f);
        RandIndex();
        ischoosin = false;
    }
    void RandIndex()
    {
       
        randomIndex = Random.Range(0, 7);
        
        Debug.Log(randomIndex);
        //tabl[randomIndex] = true;
        
    }

}
