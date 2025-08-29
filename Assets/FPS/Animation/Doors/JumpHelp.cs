using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHelp : MonoBehaviour
{
    public GameObject JumpText;
    
    void Start()
    {
        JumpText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<GoldenKey>().GotKey == false)
        {
            if (other.tag == "JumpHelp")
            {
                JumpText.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {       
        if(other.tag == "JumpHelp")
        {
            JumpText?.SetActive(false);
        }
    }

    
}
