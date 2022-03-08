using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inputs modified to recognize WASD and arrow keys

public class Slide : MonoBehaviour
{
    public BoxCollider2D bc2d;
    float bc_h;
    public float wait_time;
    private bool is_sliding = false;


    // Start is called before the first frame update
    void Start()
    {
        bc_h = bc2d.size.x; 
    }

    IEnumerator wait_Corotine()
    {
        yield return new WaitForSeconds(wait_time);
        bc2d.size = new Vector2(bc_h, bc_h);
        bc2d.offset = new Vector2(0, 0);
        is_sliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_sliding)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown("down"))
            {
                //print("pressed s");
                bc2d.size = new Vector2(bc_h, bc_h / 2);
                bc2d.offset = new Vector2(0, -bc_h / 4);
                //print(bc2d.size.y); 
                is_sliding = true;
                StartCoroutine(wait_Corotine());
            }

        }
        
    }
}
