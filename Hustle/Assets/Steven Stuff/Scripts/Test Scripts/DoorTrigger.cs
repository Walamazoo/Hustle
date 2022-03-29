using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
   
   public int triggerID;

    private void Update(){
        if (Input.GetMouseButtonDown(0)){
           EventManager.current.StartDoorEvent(triggerID);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow)){
            Debug.Log("Right");
            EventManager.current.SpeedStateChange(1);
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow)){
            Debug.Log("Left");
            EventManager.current.SpeedStateChange(-1);
        }
    } 

}
