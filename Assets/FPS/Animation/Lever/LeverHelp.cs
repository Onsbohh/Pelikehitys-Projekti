using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHelp : MonoBehaviour
{
    public GameObject LeverText;
    public GameObject CompRight;

    void Start()
    {
        LeverText.SetActive(false);
        CompRight.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "LeverTrigger")
        {
            LeverText.SetActive(true);
            
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "LeverTrigger")
        {
            if (GetComponent<LeverDoor>().solved)
            {
                CompRight.SetActive(true);
                LeverText.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "LeverTrigger")
        {
            LeverText.SetActive(false);
            CompRight.SetActive(false);
        }
    }

}
