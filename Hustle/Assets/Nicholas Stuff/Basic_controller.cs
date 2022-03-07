using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_controller : MonoBehaviour
{
    public Rigidbody2D rb;
    bool right = false;
    bool left = false;
    public float speed = 6f;
    public float jump_force = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void move_right()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

    }
    void move_left()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
    void rest()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (left)
            {
                left = false;
            }
            else
            {
                right = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (right)
            {
                right = false;
            }
            else
            {
                left = true;
            }
        }
        if (right)
        {
            move_right();
        }
        else if (left)
        {
            move_left();
        }
        else
        {
            rest();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jump_force, (ForceMode2D)ForceMode.Acceleration);
        }
    }
}
