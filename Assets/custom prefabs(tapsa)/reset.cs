using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion startRotation;
    bool putBack = false;
    int waitTime = 4;
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }
        private void OnTriggerExit(Collider other)
    {
        if ((transform.position != startPosition || transform.rotation != startRotation) && putBack == false)
        {
            putBack = true;
            StartCoroutine(takeMeHome());
            
        }
        //gameObject.SetActive(true);

    }
    IEnumerator takeMeHome()
    {

        yield return new WaitForSeconds(waitTime);
        

        transform.position = startPosition;
        transform.rotation = startRotation;
        putBack = false;
        //gameObject.SetActive(false);

    }
    
    
}
