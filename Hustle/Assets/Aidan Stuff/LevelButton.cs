using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] int LevelNumber;

    public void OnButtonPressed(){
        SceneManager.LoadScene(LevelNumber);
    }
}