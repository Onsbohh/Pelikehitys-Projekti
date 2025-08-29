using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropElevator : MonoBehaviour
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
                Player.transform.parent = transform;
                yield return new WaitForSeconds(5.5F);
                Player.transform.parent = null;
                yield return new WaitForSeconds(.5F);
                hinge.useMotor = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        HingeJoint hinge = train_Balcony.GetComponent(typeof(HingeJoint)) as HingeJoint;
        
        
            hinge.useMotor = false;

        
        
    }
}