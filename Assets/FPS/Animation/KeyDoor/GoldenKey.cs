using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenKey : MonoBehaviour
{
    [SerializeField] public GameObject key;
    [SerializeField] public Animator anim;
    public bool GotKey = false;
    public GameObject GotKeyText;
   

    void Start()
    {
        GotKeyText.SetActive(false);
        
    }
    void OnTriggerStay(Collider other)
    {
       
        if (other.tag == "KeyTrigger")
        {
            key.GetComponent<Renderer>().enabled = false;
            GotKey = true;
            anim.SetBool("KeyTrigger", false);
            GotKeyText.SetActive(true);
                
              
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "KeyTrigger")
        {
            GotKeyText?.SetActive(false);
        }
    }
    
}
