using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorLocked : MonoBehaviour
{

    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
    
    
    [SerializeField] public Animator anim;
    [SerializeField] public Animator anim2;



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Pressed();
        }
    }

    void Pressed()
    {

        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {
            if (GetComponent <GoldenKey>().GotKey)
            {
                if (doorhit.transform.tag == "DoubleDoor")
                {
                    anim.SetBool("LDoor", true);
                    anim2.SetBool("LDoor", true);
                }
            }


        }
    }

}