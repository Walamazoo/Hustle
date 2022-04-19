using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] PlayerController player;

    public Checkpoint currentCheckpoint;
    
    [SerializeField] GameEvents stateHolder;

    private Vector2 _startPosition;

     void Start()
    {
        //GameEvents.current.OnSpeedStateChange += UpdateSpeedState;
        _startPosition = player.gameObject.transform.position;
    }

    void Update(){
        if(Input.GetKeyUp(KeyCode.R)){
            Reset();
        }
    }

    void UpdateSpeedState(int direction){
        //Debug.Log("Update speed state");
        if(stateHolder.speedState !>= 3 || stateHolder.speedState !<= -3){
            stateHolder.speedState += direction;
        }
        //Debug.Log(_speedState);
    }

    void OnTriggerEnter2D(Collider2D other){
            other.gameObject.transform.position = new Vector2(currentCheckpoint.transform.position.x, currentCheckpoint.transform.position.y+1);
            if (stateHolder.speedState > currentCheckpoint.respawnSpeed){
                //Debug.Log("Decreasing speed state");
                while(stateHolder.speedState > currentCheckpoint.respawnSpeed){
                    GameEvents.current.SpeedStateChange(-1);
                    //Debug.Log(_speedState);
                }
            }
            else if(stateHolder.speedState < currentCheckpoint.respawnSpeed){
                //Debug.Log("Increasing speed state");
                while (stateHolder.speedState < currentCheckpoint.respawnSpeed){
                    GameEvents.current.SpeedStateChange(1);
                    //Debug.Log(_speedState);
                }
            }
    }

    void Reset(){
        if(currentCheckpoint == null){
            player.gameObject.transform.position = _startPosition;
        }
        
        else{
            player.gameObject.transform.position = new Vector2(currentCheckpoint.transform.position.x, currentCheckpoint.transform.position.y+2);
            
            if (stateHolder.speedState > currentCheckpoint.respawnSpeed){
                //Debug.Log("Decreasing speed state");
                while(stateHolder.speedState > currentCheckpoint.respawnSpeed){
                    GameEvents.current.SpeedStateChange(-1);
                    //Debug.Log(_speedState);
                }
            }
            else if(stateHolder.speedState < currentCheckpoint.respawnSpeed){
                //Debug.Log("Increasing speed state");
                while (stateHolder.speedState < currentCheckpoint.respawnSpeed){
                    GameEvents.current.SpeedStateChange(1);
                    //Debug.Log(_speedState);
                }
            }
            
        }
        
    }
}
