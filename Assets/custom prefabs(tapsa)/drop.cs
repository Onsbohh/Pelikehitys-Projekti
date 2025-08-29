using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
 
    public GameObject Player;
    public GameObject train_Balcony;
    

    private void OnTriggerEnter(Collider other)
    {

        HingeJoint hinge = train_Balcony.GetComponent(typeof(HingeJoint)) as HingeJoint;
       
        if (other.gameObject == Player)
        {
            {
                StartCoroutine(waiter());
            }

            IEnumerator waiter()
            {
                yield return new WaitForSeconds(.5F);

                hinge.useMotor = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        HingeJoint hinge = train_Balcony.GetComponent(typeof(HingeJoint)) as HingeJoint;
       
      
        if (hinge.useMotor == true)
            hinge.useMotor = false;

        
    }
}