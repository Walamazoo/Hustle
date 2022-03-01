using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made with help from https://www.youtube.com/watch?v=70PcP_uPuUc

public class ChangeSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.ExampleEvent += IncreaseSize;
    }

    private void IncreaseSize()
    {
        transform.localScale = new Vector3(2,2,2);
    }

    private void OnDisable(){
        EventManager.current.ExampleEvent -= IncreaseSize;
    }
}
