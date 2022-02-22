using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made with help from https://www.youtube.com/watch?v=gx0Lt4tCDE0

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> OnSpeedStateChange;

    public void SpeedStateChange(int direction){
        if(OnSpeedStateChange != null){
            OnSpeedStateChange(direction);
        }
    }
}
