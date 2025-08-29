using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLights : MonoBehaviour
{
    [Header("References")] [Tooltip("Set the type of light to place")]
    public GameObject LightObject;
    const int GRIDSIZE = 8;
    const int OBJECTDISTANCE = 12;

    public void Build()
    {
        Vector3 position;
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(-90, 0, 0);

        for (int i = 0; i < GRIDSIZE; i++)
        {
            position = transform.position + new Vector3(0, 0, i * OBJECTDISTANCE);
            for (int j = 0; j < GRIDSIZE; j++)
            {
                if (i % 2 == 1 && j % 2 == 0)
                {
                    Instantiate(LightObject, position, rotation, transform);
                }
                else if (i % 2 == 0 && j % 2 == 1)
                {
                    Instantiate(LightObject, position, rotation, transform);
                }
                position += new Vector3(OBJECTDISTANCE, 0, 0);
            }
        }
    }
}