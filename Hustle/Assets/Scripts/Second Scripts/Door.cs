using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int doorID;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.OpenDoorEvent += OpenDoor;
    }

   private void OpenDoor(int triggerID){
       if(triggerID == doorID){
           Debug.Log("Open Door");
   }
       }
}
