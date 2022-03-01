using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Made with help from https://www.youtube.com/watch?v=70PcP_uPuUc

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    public event Action ExampleEvent;
    public event Action<int> OpenDoorEvent;

    private void Awake(){
        if (current == null){
            current = this;
        }
        else{
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
   
    private void Update(){
        if (Input.GetMouseButtonDown(0)){
            /*
            if(ExampleEvent != null){
                ExampleEvent();
            }
            */

            ExampleEvent?.Invoke();
        }
    }

    public void StartDoorEvent(int id){
        OpenDoorEvent?.Invoke(id);
    }
}
