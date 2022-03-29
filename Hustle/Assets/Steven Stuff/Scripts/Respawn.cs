using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] PlayerController player;

    public Checkpoint currentCheckpoint;
    private int _speedState = 0;

     void Start()
    {
        GameEvents.current.OnSpeedStateChange += UpdateSpeedState;
    }

    void UpdateSpeedState(int direction){
        Debug.Log("Update speed state");
        if(_speedState !>= 3 || _speedState !<= -3){
            _speedState += direction;
        }
        Debug.Log(_speedState);
    }

    void OnTriggerEnter2D(Collider2D other){
        //if(other.CompareTag("Player")){
            Debug.Log("respawn");
            //other.gameObject.transform.parent.gameObject.transform.position = new Vector2(currentCheckpoint.transform.position.x, currentCheckpoint.transform.position.y+1);
            other.gameObject.transform.position = new Vector2(currentCheckpoint.transform.position.x, currentCheckpoint.transform.position.y+1);
            if (_speedState > currentCheckpoint.respawnSpeed){
                Debug.Log("Decreasing speed state");
                while(_speedState > currentCheckpoint.respawnSpeed){
                    GameEvents.current.SpeedStateChange(-1);
                    Debug.Log(_speedState);
                }
            }
            else if(_speedState < currentCheckpoint.respawnSpeed){
                Debug.Log("Increasing speed state");
                while (_speedState < currentCheckpoint.respawnSpeed){
                    GameEvents.current.SpeedStateChange(1);
                    Debug.Log(_speedState);
                }
            }
        //}
    }

}
