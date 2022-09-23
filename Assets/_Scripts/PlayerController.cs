using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] test test;

    public Vector2Int GridPosition;

    private void Start()
    {
        test = FindObjectOfType<test>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (detectCollision(GridPosition.x, GridPosition.y + 1) != 1)
            {
                if(detectCollision(GridPosition.x, GridPosition.y + 1) == 2)
                {

                }
                GridPosition.y++;
                transform.position = new Vector3(GridPosition.x * test.Distance, GridPosition.y * test.Distance) - test._offset;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (detectCollision(GridPosition.x, GridPosition.y - 1) != 1)
            {
                GridPosition.y--;
                transform.position = new Vector3(GridPosition.x * test.Distance, GridPosition.y * test.Distance) - test._offset;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (detectCollision(GridPosition.x - 1, GridPosition.y) != 1)
            {
                GridPosition.x--;
                transform.position = new Vector3(GridPosition.x * test.Distance, GridPosition.y * test.Distance) - test._offset;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (detectCollision(GridPosition.x + 1, GridPosition.y) != 1)
            {
                GridPosition.x++;
                transform.position = new Vector3(GridPosition.x * test.Distance, GridPosition.y * test.Distance) - test._offset;
            }
        }

    }

    int detectCollision(int x, int y)
    {
        if (test.GridMap[x, y] == 1)
        {
            return 1;
        }
        if (test.GridMap[x, y] == 2)
        {
            return 2;
        }
        return 0;
    }
}
