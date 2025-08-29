using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverCompination2 : MonoBehaviour
{

    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
    public bool opened2 = false;
    private Animator anim;



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Pressed();
        }
        if (GetComponent<LeverDoor>().anim.GetBool("DoorUp"))
        {
            anim.SetBool("LeverUse", false);
        }
    }

    void Pressed()
    {

        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {


            if (doorhit.transform.tag == "Lever2")
            {


                anim = doorhit.transform.GetComponentInParent<Animator>();


                opened2 = !opened2;


                anim.SetBool("LeverUse", opened2);
            }


        }
    }

}


