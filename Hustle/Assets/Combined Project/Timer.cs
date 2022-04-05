using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] bool timerIsRunning = false; 
    public TextMeshProUGUI timerText;

    public float time;
    private float minutes;
    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void FixedUpdate(){
         if(timerIsRunning){
            time += Time.deltaTime;
            minutes = Mathf.FloorToInt(time / 60); 
            seconds = Mathf.FloorToInt(time % 60);
            timerText.text = string.Format("{0:00} {1:00}", minutes, seconds);
        }
    }
}
