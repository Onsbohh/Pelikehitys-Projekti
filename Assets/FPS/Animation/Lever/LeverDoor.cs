using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : MonoBehaviour
{
    private int[] correctComp;
    private int[] compination;
    private bool l1 = false;
    private bool l2 = false;
    private bool l3 = false;
    public bool solved = false;
    
    [SerializeField] public Animator anim;
    
    private void Start()
    {
        correctComp = new int[] { 2, 1, 3 };
        compination = new int[] { 0, 0, 0 };
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "LeverTrigger")
        {
           
            if (GetComponent<LeverCombination>().opened && GetComponent<LeverCompination3>().opened3 == false)
            {
                compination[0] = 2;
                l1 = true;
            }
            if (GetComponent<LeverCompination2>().opened2 && GetComponent<LeverCombination>().opened
              == false && GetComponent<LeverCompination3>().opened3 == false)
            {
                compination[1] = 1;
                l2 = true;
            }
            if (GetComponent<LeverCompination3>().opened3 && GetComponent<LeverCombination>().opened && GetComponent<LeverCompination2>().opened2)
            {
                compination[2] = 3;
                l3 = true;
            }
            if (l1 && l2 && l3)
            {
                if (compination[0] == correctComp[0] && compination[1] == correctComp[1] && compination[2] == correctComp[2])
                {
                    anim.SetBool("DoorUp", true);  
                    solved = true;
                }
            }
            if (GetComponent<LeverCombination>().opened == false)
            {
                l1 = false;
            }
            if (GetComponent<LeverCompination2>().opened2 == false)
            {
                l2 = false;
            }
            if (GetComponent<LeverCompination3>().opened3 == false)
            {
                l3 = false;
            }
        }
    }

}

