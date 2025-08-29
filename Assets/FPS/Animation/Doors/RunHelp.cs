using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunHelp : MonoBehaviour
{
    public GameObject Runtxt;
    void Start()
    {
        Runtxt.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RunHelp")
        {
            Runtxt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "RunHelp")
        {
            Runtxt.SetActive(false);
        }
    }
}
