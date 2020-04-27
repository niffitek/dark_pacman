using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemWithPlayer : MonoBehaviour
{
    private static int nb = 0;
    public Light my_pointlight;
    private float lighttime = 0;
    public bool col = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "itemWall")
        {
            col = false;
            Destroy(collision.gameObject, 0);
        }
        if (collision.name == "itemTime")
        {
            FindObjectOfType<Text_handler>().time_left += 15;
            Destroy(collision.gameObject, 0);
        }
        if (collision.name == "BigLight")
        {
            lighttime = 5;
            my_pointlight.range = 1000;
            Destroy(collision.gameObject, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (col == false && collision.collider.name == "Wall")
        {
            Destroy(collision.collider.gameObject, 0);
            nb++;
            if (nb == 3)
            {
                col = true;
                nb = 0;
            }
        }
    }

    private void Update()
    {
        lighttime -= Time.deltaTime;
        if (my_pointlight.range == 1000 && lighttime <= 0)
        {
            my_pointlight.range = 3;
        }
    }
}
