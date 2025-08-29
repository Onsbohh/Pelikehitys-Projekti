using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMSG : MonoBehaviour
{
    public GameObject Starttxt;
    public GameObject Startbkr;

    void Start()
    {
        Starttxt.SetActive(true);  
        Startbkr.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "StartMSG")
        {
            Starttxt.SetActive(false);
            Startbkr.SetActive(false);
        }
    }
    
}
