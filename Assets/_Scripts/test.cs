using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject player;
    public GameObject floor_valid;
    public GameObject floor_obstacle;
    public GameObject floor_spawn;
    public GameObject floor_blockBleu;
    public GameObject floor_endBlockBleu;

    public const char sstart = 'S';
    public const char sfloor_valid = '0';
    public const char sfloor_obstacle = '1';
    public const char sfloor_blockBleu = 'A';
    public const char sfloor_finBlockBleu = 'B';


    public float Distance;
    public Vector3 _offset;

    public int Height;
    public int Width;

    public PlayerController playerController;

    public int[,] GridMap;
    public GameObject[,] DynamicMap;

    void Start()
    {

        char[,] jagged = readFile(Application.dataPath + "/Ressource/Map.txt");
        GridMap = new int[Width, Height];

        int height = jagged.GetLength(1) - 1 ;
        for (int y = 0; y < jagged.GetLength(1); y++)
        {
            for (int x = 0; x < jagged.GetLength(0); x++)
            {
                switch (jagged[x, y])
                {
                    case sstart:
                        GameObject gofs = GameObject.Instantiate(floor_spawn);
                        gofs.transform.position = new Vector3(x * Distance, (height- y) * Distance ) - _offset;
                        GameObject goPlayer = GameObject.Instantiate(player);
                        goPlayer.transform.position = new Vector3(x * Distance, (height - y) * Distance) - _offset;
                        playerController = FindObjectOfType<PlayerController>();
                        playerController.GridPosition = new Vector2Int(x, height - y);
                        GridMap[x, y] = 0;
                        break;
                    case sfloor_valid:
                        GameObject gofv = GameObject.Instantiate(floor_valid);
                        gofv.transform.position = new Vector3(x * Distance, (height - y) * Distance) - _offset;
                        break;
                    case sfloor_obstacle:
                        GameObject gofo = GameObject.Instantiate(floor_obstacle);
                        gofo.transform.position = new Vector3(x * Distance, (height - y) * Distance) - _offset;
                        GridMap[x, height - y] = 1;
                        break;
                    case sfloor_blockBleu:
                        GameObject gobb = GameObject.Instantiate(floor_blockBleu);
                        gobb.transform.position = new Vector3(x * Distance, (height - y) * Distance) - _offset;
                        GridMap[x, height - y] = 2;
                        break;
                    case sfloor_finBlockBleu:
                        GameObject goebb = GameObject.Instantiate(floor_endBlockBleu);
                        goebb.transform.position = new Vector3(x * Distance, (height - y) * Distance) - _offset;
                        GridMap[x, height - y] = 3;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

        }
    }

    char[,] readFile(string file)
    {
        string[] lines = File.ReadAllLines(file);
        Height = lines.Length;
        Width = lines[0].Length;
        char[,] map = new char[Width, Height];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                map[x, y] = lines[y][x];
                //GridMap[x, y] = lines[y][x];
            }
        }
        _offset = new Vector3((Width * Distance) / 2, (Height * Distance) / 2);

        return map;
    }
}
