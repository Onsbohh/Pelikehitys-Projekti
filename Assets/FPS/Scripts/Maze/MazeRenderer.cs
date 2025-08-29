using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MazeRenderer : MonoBehaviour
{
    private int _width = 15;
    private int _length = 15;
    private const int WALLSIZE = 6;

    [Header("References")] [Tooltip("Set the prefab for the maze walls")]
    public GameObject MazeWall = null;
    [Tooltip("Set the objects to be included in NavMesh generation")]
    public NavMeshSurface Surface;
    [Tooltip("Set the parent object for enemies")]
    public Transform EnemyParent;
    [Tooltip("Set the prefab for enemies")]
    public GameObject Enemy;

    void Awake()
    {
        var maze = MazeGenerator.Generate(_width, _length);
        var enemyGrid = EnemyGenerator.Generate(_width, _length);
        List<GameObject> leftWalls = GenerateList("MazeWallLeft");
        List<GameObject> topWalls = GenerateList("MazeWallTop");
        Draw(maze, enemyGrid, leftWalls, topWalls);
        Surface.BuildNavMesh();
        DrawEnemy(enemyGrid);
    }

    private void Draw(WallState[,] maze, bool[,] enemyGrid, List<GameObject> leftWalls, List<GameObject> topWalls)
    {
        leftWalls[0].SetActive(false);

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                var cell = maze[i,j];

                if (!cell.HasFlag(WallState.LEFT))
                {
                    leftWalls[i * _length + j].SetActive(false);
                }
                
                if (!cell.HasFlag(WallState.UP))
                {
                    topWalls[i * _length + j].SetActive(false);
                }
            }
        }
    }

    private List<GameObject> GenerateList(string tag)
    {
        List<GameObject> walls = new List<GameObject>();
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag(tag))
        {
            walls.Add(wall);
        }
        
        walls.Sort(SortByName);
        return walls;
    }

    private static int SortByName(GameObject objA, GameObject objB)
    {
        return objA.name.CompareTo(objB.name);
    }

    private void DrawEnemy(bool[,] enemyGrid)
    {
        Vector3 position;
        Quaternion rotation = Quaternion.identity;

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                position = EnemyParent.position + new Vector3(i * WALLSIZE, 0, j * WALLSIZE);
                rotation.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);

                if (enemyGrid[i,j])
                {
                    Instantiate(Enemy, position, rotation, EnemyParent);
                }
            }
        }
    }
}