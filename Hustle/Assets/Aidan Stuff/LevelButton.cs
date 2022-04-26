using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Globalization;
using System;

public class LevelButton : MonoBehaviour
{
    [SerializeField] int LevelNumber;
    string path;
    string[] lines;
    float time;
    string timeToDisplay;

    public void OnButtonPressed(){
        SceneManager.LoadScene(LevelNumber);
    }

    void Start(){
    path = Application.dataPath + "/Aidan Stuff/" + "SavedTimes.txt";   
    lines = File.ReadAllLines(path);
    time =  float.Parse(lines[LevelNumber], CultureInfo.InvariantCulture.NumberFormat);
    float seconds = Mathf.FloorToInt(time % 60);
    float minutes = Mathf.FloorToInt(time / 60); 
    timeToDisplay = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    void OnMouseEnter()
    {
        if(time == 0.0f){
            GameObject.Find("LevelButton").GetComponentInChildren<Text>().text = "N/A";
        }
        else{
            GameObject.Find("LevelButton").GetComponentInChildren<Text>().text = timeToDisplay;
        }
    }

    void OnMouseExit()
    {
        GameObject.Find("LevelButton").GetComponentInChildren<Text>().text = "";
    }
    
}