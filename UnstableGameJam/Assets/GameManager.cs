using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //pleind e varaibale game object 
    public GameObject pressButton;
    public GameObject spamPressButton;
    public GameObject twoPressButton;
    public GameObject pavNumerique;
    public GameObject switchPress;
    public bool[] tabl;
    public int randomIndex;
    public bool ischoosin;
    public bool boll;
    void Start()
    {
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
                default:
                    Debug.Log("pas d'autre rand");
                    break;
            }
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
       
        randomIndex = Random.Range(0, 5);
        
        Debug.Log(randomIndex);
        //tabl[randomIndex] = true;
        
    }

}
