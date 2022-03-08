using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inputs modified to recognize WASD and arrow keys

public class PlayerController : Player
{
    Vector2 move;
    public float jumpTakeOffSpeed = 3f;
    int speedState = 0;
    bool ticked;
    float tickTimer = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        move = Vector2.zero;
        ticked = false;
    }

    protected override void ComputeVelocity(){

        if(Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.D)){

            //New code using Event System
            GameEvents.current.SpeedStateChange(1);

            speedState += 1;
            if(speedState > 3){
                speedState = 3;
            }
        }
        if(Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.A)){

            //New code using Event System
            GameEvents.current.SpeedStateChange(-1);

            speedState -= 1;
            if(speedState < -3){
                speedState = -3;
            }
        }

        maxSpeed(speedState);

        if((Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.W)) && grounded){
            velocity.y = jumpTakeOffSpeed + Mathf.Abs(move.x/2.5f);
        }
        else if(Input.GetKeyUp("up") || Input.GetKeyDown(KeyCode.W)){
            if(velocity.y > 0f){
                velocity.y = velocity.y * 0.5f;
            }
        }

        targetVelocity = move;
    }

    void maxSpeed(int state){
        if(ticked == true){
            tickTimer -= Time.deltaTime;
            if(tickTimer <= 0.0f){
                ticked = false;
                tickTimer = 0.1f;
            }
        }

        else if(state == -3 && ticked == false){
            if(move.x > -15f){
                move.x -= 0.5f;
                ticked = true;
            }
            
            if(move.x < -15f){
                move.x = -15f;
            }
        }
        
        else if(state == -2 && ticked == false){
            if(move.x > -10f){
                move.x -= 0.5f;
                ticked = true;
            }
            
            if(move.x < -10f){
                move.x += 0.5f;
                ticked = true;
            }
        }

        else if(state == -1 && ticked == false){
            if(move.x > -5f){
                move.x -= 0.5f;
                ticked = true;
            }
            
            if(move.x < -5f){
                move.x += 0.5f;
                ticked = true;
            }
        }

        else if(state == 0 && ticked == false){
            if(move.x > 0f){
                move.x -= 0.5f;
                ticked = true;
            }
            
            if(move.x < 0f){
                move.x += 0.5f;
                ticked = true;
            }
        }

        else if(state == 1 && ticked == false){
            if(move.x > 5f){
                move.x -= 0.5f;
                ticked = true;
            }
            
            if(move.x < 5f){
                move.x += 0.5f;
                ticked = true;
            }
        }

        else if(state == 2 && ticked == false){
            if(move.x > 10f){
                move.x -= 0.5f;
                ticked = true;
            }
            
            if(move.x < 10f){
                move.x += 0.5f;
                ticked = true;
            }
        }

        else if(state == 3 && ticked == false){
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
