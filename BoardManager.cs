using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int colums = 8;
    public int rows = 8;

    public GameObject[] floorTiles, outerWallTiles; //Losetas

    private Transform boardHolder;

  public void SetupScene()
    {
        BoardSetup();
    }
    void BoardSetup()
    {
        new GameObject("Board");

        for (int x = -1; x<colums + 1; x++)
        {
            for (int y= -1; x <rows+1; y++)
            {
                GameObject toInstantiate = GetRandomInArray(floorTiles);

                if ( x==-1 || y == -1 || x == colums || y == rows)
                {
                    toInstantiate = GetRandomInArray(outerWallTiles);
                }
                Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity);
            }
        }
    }

    GameObject GetRandomInArray (GameObject[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}
