using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlaceWalls : MonoBehaviour
{
    // Sets the length and width of the maze
    private int _width = 15;
    private int _length = 15;
    private const int WALLSIZE = 6;     // The width of the wall

    [Header("References")] [Tooltip("Set the prefab for the maze walls")]
    public GameObject MazeWall = null;

    public void Build()
    {
        Vector3 position;
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles += new Vector3(0, 90, 0);
        
        GameObject leftWalls = new GameObject("Left_Walls");
        leftWalls.transform.parent = gameObject.transform;

        GameObject topWalls = new GameObject("Top_Walls");
        topWalls.transform.parent = gameObject.transform;

        GameObject rightWalls = new GameObject("Right_Walls");
        rightWalls.transform.parent = gameObject.transform;

        GameObject bottomWalls = new GameObject("Bottom_Walls");
        bottomWalls.transform.parent = gameObject.transform;

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                position = transform.position + new Vector3(i * WALLSIZE, 0, j * WALLSIZE);

                var leftWall = Instantiate(MazeWall, position, Quaternion.identity, leftWalls.transform);
                var topWall = Instantiate(MazeWall, position + new Vector3(0, 0, WALLSIZE), rotation, topWalls.transform);
                
                leftWall.name = string.Format("Left_Wall_{0:D3}", (i * _length + j) + 1);
                leftWall.tag = "MazeWallLeft";
                topWall.name = string.Format("Top_Wall_{0:D3}", (i * _length + j) + 1);
                topWall.tag = "MazeWallTop";

                if (i == _width - 1 && j < _length - 1)
                {
                    var rightWall = Instantiate(MazeWall, position + new Vector3(WALLSIZE, 0, 0), Quaternion.identity, rightWalls.transform);
                    rightWall.name = string.Format("Right_Wall_{0:D2}", j + 1);
                }

                if (j == 0)
                {
                    var bottomWall = Instantiate(MazeWall, position, rotation, bottomWalls.transform);
                    bottomWall.name = string.Format("Bottom_Wall_{0:D2}", i + 1);
                }
            }
        }
    }
}