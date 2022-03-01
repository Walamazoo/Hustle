using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made with help from https://www.youtube.com/watch?v=gx0Lt4tCDE0

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    public event Action<int> OnSpeedStateChange;

    private void Awake()
    {
         if (current == null){
            current = this;
        }
        else{
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SpeedStateChange(int direction){
        //Debug.Log("SpeedStateChange");
        if(OnSpeedStateChange != null){
            OnSpeedStateChange(direction);
        }
    }
}
