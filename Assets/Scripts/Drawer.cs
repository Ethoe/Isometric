using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Objects;

public class Drawer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blueTile;
    public GameObject[,] map;
    int x = 4, y = 4;
    void Start()
    {
        map = new GameObject[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                var spawnLoc = Objects.Transformer.toScreenCoordinate(new Vector2(i, j));
                Debug.Log(spawnLoc);
                var block = Instantiate(blueTile, spawnLoc, Quaternion.identity);
                map[i, j] = block;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        {
            var loc = GetMouseLocation();
            Debug.Log(loc);
            if (0 <= loc.x && loc.x < x && 0 <= loc.y && loc.y < y)
            {
                map[(int)loc.x, (int)loc.y].GetComponent<Tile>().bounce();
            }
        }
    }

    private Vector2 GetMouseLocation()
    {
        return Objects.Transformer.toGridCoordinate(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
