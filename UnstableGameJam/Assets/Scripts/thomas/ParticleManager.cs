using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public GameObject[] particle;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < particle.Length; i++)
        {
            particle[i].SetActive(false);
        }
        //SetActive(false);
        StartCoroutine(WaitFire());
    }
    IEnumerator WaitFire()
    {

        for (int i = 0; i < particle.Length; i+=2)
        {
            yield return new WaitForSeconds(5);
            particle[i].SetActive(true);
            particle[i + 1].SetActive(true);
        }
        
        //particle[1].SetActive(true);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
