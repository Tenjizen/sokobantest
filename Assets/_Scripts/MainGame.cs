using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
//using DG.Tweening;


public class MainGame : MonoBehaviour
{
    public GameObject[] Prefabs;

    //public Vector2Int[] PosWall;

    public int Wight;
    public int Hight;

    public int[,] Map;

    public float Distance;



    private Vector3 _offset;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        string map = Application.dataPath + "/Ressource/Map.txt";
        string test = File.ReadAllText(map);
        print(test);

        Map = new int[Wight, Hight];
        


        _offset = new Vector3((Wight * Distance) / 2, (Hight * Distance) / 2);

        //foreach (var pos in PosWall)
        //{
        //    PosPrefab(pos, 1);
        //}
        yield return PlaceMap();
        yield return PlaceWall();
    }





    //Update is called once per frame
    //void Update()
    //{

    //}
    //public void PosPrefab(Vector2Int pos, int prefab)
    //{
    //    Map[pos.x, pos.y] = prefab;
    //}
    IEnumerator PlaceMap()
    {
        for (int x = 0; x < Wight; x++)
        {
            for (int y = 0; y < Hight; y++)
            {

                GameObject go = GameObject.Instantiate(Prefabs[0]);
                go.transform.position = new Vector3(x * Distance, y * Distance) - _offset;


            }
            yield return new WaitForSeconds(0.05f);
        }
    }


    IEnumerator PlaceWall()
    {
        for (int x = 0; x < Wight; x++)
        {
            for (int y = 0; y < Hight; y++)
            {
                if (x == 0 || x == Wight - 1 || y == 0 || y == Hight - 1)
                {
                    GameObject go = GameObject.Instantiate(Prefabs[1]);
                    go.transform.position = new Vector3(x * Distance, y * Distance) - _offset;
                }
            }
        }
        yield return new WaitForSeconds(0.05f);

    }
}
