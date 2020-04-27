using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float move_speed = 0.1f;
    public Animator animator;
    public GameObject light;
    public int x, y, z;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move_vec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 light_pos = new Vector3(light.transform.position.x, light.transform.position.y, light.transform.position.z);
        Vector3 player_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);


        Vector3 light_rot = new Vector3(light.transform.localRotation.x, light.transform.localRotation.y, light.transform.localRotation.y);



        if (Input.GetKey(KeyCode.W))
        {
            move_vec.y += move_speed;
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Speed", move_vec.sqrMagnitude);
            light_pos.x = player_pos.x;
            light_pos.y = player_pos.y - 3;
            x = 270;
            y = 0;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            move_vec.x -= move_speed;
            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", move_vec.sqrMagnitude);
            light_pos.x = player_pos.x + 3;
            light_pos.y = player_pos.y;
            x = 0;
            y = 270;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move_vec.y -= move_speed;
            animator.SetFloat("Vertical", -1);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Speed", move_vec.sqrMagnitude);
            light_pos.x = player_pos.x;
            light_pos.y = player_pos.y + 3;
            x = 90;
            y = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move_vec.x += move_speed;
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", move_vec.sqrMagnitude);
            light_pos.x = player_pos.x - 3;
            light_pos.y = player_pos.y;
            x = 0;
            y = 90;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            move_vec.x = 1;
            move_vec.y = 1;
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("main_menu");
        }
        else
        {
            animator.SetFloat("Speed", 0);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
        }
        transform.position = move_vec;
        light.transform.rotation = Quaternion.Euler(x, y, z);
        light.transform.position = light_pos;
    }
}
