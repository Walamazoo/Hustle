using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made with help from https://www.youtube.com/watch?v=70PcP_uPuUc

public class ChangeColor : MonoBehaviour
{
    public Color newColor;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.ExampleEvent += SetNewColor;
    }

    private void SetNewColor()
    {
        GetComponent<SpriteRenderer>().color = newColor;
    }

    private void OnDisable(){
        EventManager.current.ExampleEvent -= SetNewColor;
    }
}