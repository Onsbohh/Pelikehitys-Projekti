using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlaceLights))]
public class PlaceLightsGUI : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PlaceLights lights = (PlaceLights)target;
        if(GUILayout.Button("Place Lights"))
        {
            lights.Build();
        }
    }
}