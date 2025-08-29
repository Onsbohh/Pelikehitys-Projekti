using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;


public class tapaPelaaja : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().Kill();
        }
    }
}
