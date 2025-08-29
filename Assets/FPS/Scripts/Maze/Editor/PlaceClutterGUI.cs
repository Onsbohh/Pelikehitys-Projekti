using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlaceClutter))]
public class PlaceClutterGUI : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PlaceClutter clutter = (PlaceClutter)target;
        if(GUILayout.Button("Place Objects"))
        {
            clutter.Build();
        }
    }
}