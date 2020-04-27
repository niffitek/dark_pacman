using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maze_sprite : MonoBehaviour
{
    SpriteRenderer sRenderer;

    void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite sprite, int sortingOrder)
    {
        sRenderer.sprite = sprite;
        sRenderer.sortingOrder = sortingOrder;
    }

    public void SetSprite(Sprite sprite)
    {
        SetSprite(sprite, 0);
    }

    public void delete()
    {
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<maze_gen_script>().mazeHeight += 2;
        FindObjectOfType<maze_gen_script>().mazeWidth += 2;
        FindObjectOfType<maze_gen_script>().level += 1;
        FindObjectOfType<maze_gen_script>().mazeSeed += "to";
        FindObjectOfType<Text_handler>().time_left += 15;
        FindObjectOfType<Score_saver>().level = FindObjectOfType<maze_gen_script>().level;
        FindObjectOfType<maze_gen_script>().Delete_maze();
        FindObjectOfType<maze_gen_script>().Start_gen();
        Destroy(this);
    }
}
