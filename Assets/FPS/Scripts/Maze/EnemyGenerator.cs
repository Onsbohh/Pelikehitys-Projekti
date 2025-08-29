using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyGenerator
{
    public static bool[,] Generate(int width, int length)
    {
        bool[,] _hasEnemy = new bool[width,length];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (i < width - 1 && j < length - 1)
                {
                    _hasEnemy[i,j] = RandomBool();
                }
            }
        }
        return _hasEnemy;
    }

    private static bool RandomBool()
    {
        bool result;
        if (Random.value <= 0.2f)
        {
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }
}
