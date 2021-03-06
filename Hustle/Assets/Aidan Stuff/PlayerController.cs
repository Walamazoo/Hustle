using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inputs modified to recognize WASD and arrow keys

public class PlayerController : Player
{
    
    Vector2 move;
    float deltaVelocity;
    public float jumpTakeOffSpeed = 3f;
    public int speedState = 0;
    bool ticked;
    float tickTimer = 0.075f;
    bool just_wall_jumped = false;
    public bool running = true;

    //Wall jump stuff
    int saved_speedState = 0;
    float saved_velocity;
    public BoxCollider2D check_collider;
    void Start()
    {
        move = Vector2.zero;
        ticked = false;
    }

    protected override void ComputeVelocity(){
        if(running){
            if((Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.D)) && (!Slide.is_sliding && !just_wall_jumped))
            {

                //New code using Event System
                GameEvents.current.SpeedStateChange(1);

                speedState += 1;
                if(speedState > 3){
                    speedState = 3;
                }
            }
            if((Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.A)) && (!Slide.is_sliding && !just_wall_jumped))
            {

                //New code using Event System
                GameEvents.current.SpeedStateChange(-1);

                speedState -= 1;
                if(speedState < -3){
                    speedState = -3;
                }
            }

            if(Input.GetKeyDown("space") && (!Slide.is_sliding && !just_wall_jumped)){
                if(speedState > 0){
                    int i = speedState;
                    while(i > 0){
                        GameEvents.current.SpeedStateChange(-1);
                        i--;
                    }
                }
                else{
                    int i = speedState;
                    while(i < 0){
                        GameEvents.current.SpeedStateChange(1);
                        i++;
                    }
                }
                speedState = 0;
            }

            maxSpeed(speedState);

            if((Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.W)) && grounded){
                if(Mathf.Abs(speedState) == 1 || speedState == 0){
                    velocity.y = jumpTakeOffSpeed + Mathf.Abs(move.x);
                }
                else{
                    velocity.y = jumpTakeOffSpeed + Mathf.Abs(move.x/1.5f);
                }
            }
            //Wall jump stuff

            if(velocity.x == 0 && !grounded)
            {
                print(speedState);
            
                if (Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.W)){
                    int i = 2 *speedState;
                    //just_wall_jumped = true;
                    if (speedState > 0)
                    {
                        while(i > 0)
                        {
                            GameEvents.current.SpeedStateChange(-1);
                            speedState -= 1;
                            i--;
                        }
                    }
                    else
                    {
                        while (i < 0)
                        {
                            GameEvents.current.SpeedStateChange(1);
                            speedState += 1;
                            i++;
                        }
                    }
                    velocity.x = speedState *5f;
                    move.x = speedState * 5f;
                    velocity.y = jumpTakeOffSpeed + Mathf.Abs(move.x / 1.75f);
                    print(speedState);
                }
            }
            if (grounded)
            {
                just_wall_jumped = false;
            }
        
      
            deltaVelocity = Mathf.Abs(velocity.x - move.x);
            targetVelocity = move;
        }
    }

    void maxSpeed(int state){
        if(running){
        
            if(deltaVelocity > 1.5f){
                move.x = 0;
            }
            
            if(ticked == true){
                tickTimer -= Time.deltaTime;
                if(tickTimer <= 0.0f){
                    ticked = false;
                    tickTimer = 0.05f;
                }
            }
            
            if(!ticked){
                if(state == -3){
                    if(move.x > -15f){
                        move.x -= 0.5f;
                        ticked = true;
                    }
                    
                    if(move.x < -15f){
                        move.x = -15f;
                    }
                }
                
                else if(state == -2){
                    if(move.x > -10f){
                        move.x -= 0.5f;
                        ticked = true;
                    }
                    
                    if(move.x < -10f){
                        move.x += 0.5f;
                        ticked = true;
                    }
                }

                else if(state == -1){
                    if(move.x > -5f){
                        move.x -= 0.5f;
                        ticked = true;
                    }
                    
                    if(move.x < -5f){
                        move.x += 0.5f;
                        ticked = true;
                    }
                }

                else if(state == 0){
                    if(move.x > 0f){
                        move.x -= 0.5f;
                        ticked = true;
                    }
                    
                    if(move.x < 0f){
                        move.x += 0.5f;
                        ticked = true;
                    }
                }

                else if(state == 1){
                    if(move.x > 5f){
                        move.x -= 0.5f;
                        ticked = true;
                    }
                    
                    if(move.x < 5f){
                        move.x += 0.5f;
                        ticked = true;
                    }
                }

                else if(state == 2){
                    if(move.x > 10f){
                        move.x -= 0.5f;
                        ticked = true;
                    }
                    
                    if(move.x < 10f){
                        move.x += 0.5f;
                        ticked = true;
                    }
                }

                else if(state == 3){
                    if(move.x > 15f){
                        move.x = 15f;
                    }
                    
                    if(move.x < 15f){
                        move.x += 0.5f;
                        ticked = true;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        just_wall_jumped = true;
        if(collision.tag == "end"){
            running = false;
            speedState = 0;
            move.x = 0f;
            velocity.x = 0f;
            GameEvents.current.LevelCompleteChange();
        }
    }
}
