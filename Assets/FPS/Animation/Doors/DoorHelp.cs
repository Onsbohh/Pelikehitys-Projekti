using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHelp : MonoBehaviour
{
    public GameObject DoorText;
    
    void Start()
    {
        DoorText.SetActive(false);  
    }

    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<GoldenKey>().GotKey == false)
        {
            if (other.tag == "DoorHelp")
            {
                DoorText.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "DoorHelp")
        {
            DoorText.SetActive(false);
        }
    }
  

   

}
