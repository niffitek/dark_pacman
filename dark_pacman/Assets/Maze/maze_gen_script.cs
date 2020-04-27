using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maze_gen_script : MonoBehaviour
{
    public int mazeWidth;
    public int mazeHeight;
    public string mazeSeed;
    public int level;

    public Sprite floorSprite;
    public Sprite roofSprite;
    public Sprite wallSprite;
    public Sprite wallCornerSprite;

    public maze_sprite mazeSpritePrefab;

    public GameObject itemWall;
    public GameObject player;
    public GameObject itemTime;
    public GameObject BigLight;

    System.Random mazeRG;

    Maze maze;

    void Start()
    {
        Start_gen();
    }

    public void Start_gen()
    {
        mazeRG = new System.Random(mazeSeed.GetHashCode());

        if (mazeWidth % 2 == 0)
            mazeWidth++;

        if (mazeHeight % 2 == 0)
        {
            mazeHeight++;
        }

        maze = new Maze(mazeWidth, mazeHeight, mazeRG);
        maze.Generate();

        DrawMaze();
    }

    public void Delete_maze()
    {
        var Wally = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var item in Wally)
        {
            Destroy(item);
        }
    }

    void DrawMaze()
    {
        for (int x = 0; x < mazeWidth; x++)
        {
            for (int y = 0; y < mazeHeight; y++)
            {
                Vector3 position = new Vector3(x, y);
                if (x == 1 && y == 1)
                {
                    position.z = -1;
                    player.transform.position = position;

                }
                if (maze.Grid[x, y] == true)
                {
                    CreateMazeSprite(position, floorSprite, transform, 0, 0);
                }
                else
                {
                    CreateMazeSprite(position, roofSprite, transform, 0, 0);

                    DrawWalls(x, y);
                }
            }
        }
    }

    void DrawWalls(int x, int y)
    {
        bool top = GetMazeGridCell(x, y + 1);
        bool bottom = GetMazeGridCell(x, y - 1);
        bool right = GetMazeGridCell(x + 1, y);
        bool left = GetMazeGridCell(x - 1, y);

        Vector3 position = new Vector3(x , y);

        if (top)
        {
            CreateMazeSprite(position, wallSprite, transform, 1, 0);
        }

        if (left)
        {
            CreateMazeSprite(position, wallSprite, transform, 1, 0);
        }

        if (bottom)
        {
            CreateMazeSprite(position, wallSprite, transform, 1, 0);
        }

        if (right)
        {
            CreateMazeSprite(position, wallSprite, transform, 1, 0);
        }

        if (!left && !top && x > 0 && y < mazeHeight - 1)
        {
            CreateMazeSprite(position, wallCornerSprite, transform, 2, 0);
        }

        if (!left && !bottom && x > 0 && y > 0)
        {
            CreateMazeSprite(position, wallCornerSprite, transform, 2, 0);
        }

        if (!right && !bottom && x < mazeWidth - 1 && y > 0)
        {
            CreateMazeSprite(position, wallCornerSprite, transform, 2, 0);
        }

        if (!right && !top && x < mazeWidth - 1 && y < mazeHeight - 1)
        {
            CreateMazeSprite(position, wallCornerSprite, transform, 2, 0);
        }
    }

    public bool GetMazeGridCell(int x, int y)
    {
        if (x >= mazeWidth || x < 0 || y >= mazeHeight || y <= 0)
        {
            return false;
        }

        return maze.Grid[x, y];
    }

    void CreateMazeSprite(Vector3 position, Sprite sprite, Transform parent, int sortingOrder, float rotation)
    {
        maze_sprite mazeSprite = Instantiate(mazeSpritePrefab, position, Quaternion.identity) as maze_sprite;
        mazeSprite.SetSprite(sprite, sortingOrder);
        mazeSprite.transform.SetParent(parent);
        mazeSprite.transform.Rotate(0, 0, rotation);
        if (position.x == mazeWidth - 2 && position.y == mazeHeight - 2)
            mazeSprite.GetComponent<BoxCollider2D>().isTrigger = true;
        else if (sprite == floorSprite)
        {
            int r = Random.Range(0, 50);
            if (r == 4)
            {
                GameObject it = (GameObject)Instantiate(itemWall, position, Quaternion.identity);
                it.GetComponent<BoxCollider2D>().isTrigger = true;
                it.name = "itemWall";
            }
            if (r == 11)
            {
                GameObject it = (GameObject)Instantiate(itemTime, position, Quaternion.identity);
                it.GetComponent<BoxCollider2D>().isTrigger = true;
                it.name = "itemTime";
            }
            if (r == 3)
            {
                GameObject it = (GameObject)Instantiate(BigLight, position, Quaternion.identity);
                it.GetComponent<BoxCollider2D>().isTrigger = true;
                it.name = "BigLight";
            }
            mazeSprite.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            mazeSprite.gameObject.tag = "Wall";
            mazeSprite.name = "Wall";
        }
    }
}
