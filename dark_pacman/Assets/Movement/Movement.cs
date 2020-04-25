using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float move_speed;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move_vec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.W))
        {
            move_vec.y += move_speed;
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Speed", move_vec.sqrMagnitude);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            move_vec.x -= move_speed;
            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", move_vec.sqrMagnitude);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move_vec.y -= move_speed;
            animator.SetFloat("Vertical", -1);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Speed", move_vec.sqrMagnitude);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move_vec.x += move_speed;
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", move_vec.sqrMagnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
        }
        transform.position = move_vec;
    }
}
