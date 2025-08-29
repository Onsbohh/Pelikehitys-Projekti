using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlaceWalls))]
public class PlaceWallsGUI : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PlaceWalls walls = (PlaceWalls)target;
        if(GUILayout.Button("Place Walls"))
        {
            walls.Build();
        }
    }
}