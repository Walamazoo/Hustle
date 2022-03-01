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
    } 

}
