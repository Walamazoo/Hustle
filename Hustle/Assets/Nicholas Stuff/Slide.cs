using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inputs modified to recognize WASD and arrow keys

public class Slide : MonoBehaviour
{
    public BoxCollider2D bc2d;
    float bc_h;
    public static bool is_sliding = false;
    public static bool can_stop_sliding = true;
    int layerMask = 1 << 6;
    public static float shifted_value = 1f;
    Vector3 direction;
    //public GameObject trail;

    public static Slide slide;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        bc_h = bc2d.size.x; 
    }

    void CanStop()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + direction, transform.TransformDirection(Vector2.up), 2f, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - direction, transform.TransformDirection(Vector2.up), 2f, layerMask);
        if (hit || hit2)
        {
            can_stop_sliding = false;            
        }
        else if (!hit && !hit2)
        {
            can_stop_sliding = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(shifted_value, 0, 0);
        
        CanStop();
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown("down")|| is_sliding)
        {
            print("pressed s");
            bc2d.size = new Vector2(bc_h, bc_h / 2);
            bc2d.offset = new Vector2(0, -bc_h / 4);
            //print(bc2d.size.y); 
            is_sliding = true;
            can_stop_sliding = false;


        }
        if(Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp("up")||can_stop_sliding)
        {
            is_sliding = false;
            if (can_stop_sliding)
            {
                //Debug.LogError("should stop");
                is_sliding = false;
                bc2d.size = new Vector2(bc_h, bc_h);
                bc2d.offset = new Vector2(0, 0);
            }
        }

wd

    }
        
    
}
