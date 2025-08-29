using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceClutter : MonoBehaviour
{
    [Header("References")] [Tooltip("Set the type of object to place")]
    public GameObject[] ClutterObject = new GameObject[4];
    private enum CornerState
    {
        BottomRight = 1,
        BottomLeft = 2,
        TopRight = 3,
        TopLeft = 4,
    }

    
    const int GRIDSIZE = 15;
    const int OBJECTDISTANCE = 6;

    public void Build()
    {
        Vector3 position;
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(-90, 0, 130);

        for (int i = 0; i < GRIDSIZE; i++)
        {
            position = transform.position + new Vector3(0, 0, i * OBJECTDISTANCE);
            for (int j = 0; j < GRIDSIZE; j++)
            {
                Array values = Enum.GetValues(typeof(CornerState));
                CornerState randomCorner = (CornerState)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                switch (randomCorner)
                {
                    case CornerState.BottomRight:
                        rotation.eulerAngles = new Vector3(-90, 0, 130);
                        Instantiate(ClutterObject[(int)CornerState.BottomRight - 1], position + new Vector3(0, 0.02f, 0), rotation, transform);
                        break;
                    case CornerState.BottomLeft:
                        rotation.eulerAngles = new Vector3(-60, 60, 190);
                        Instantiate(ClutterObject[(int)CornerState.BottomLeft - 1], position + new Vector3(0, 0, 4), rotation, transform);
                        break;
                    case CornerState.TopRight:
                        rotation.eulerAngles = new Vector3(-90, 0, 130);
                        Instantiate(ClutterObject[(int)CornerState.TopRight - 1], position + new Vector3(4, 0.01f, 0), rotation, transform);
                        break;
                    case CornerState.TopLeft:
                        rotation.eulerAngles = new Vector3(-90, 0, 130);
                        Instantiate(ClutterObject[(int)CornerState.TopLeft - 1], position + new Vector3(4, 0, 4), rotation, transform);
                        break;
                }
                position += new Vector3(OBJECTDISTANCE, 0, 0);
            }
        }
    }
}