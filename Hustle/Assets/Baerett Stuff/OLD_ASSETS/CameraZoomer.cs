using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    Camera camera;
    public float minSize, maxSize;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCamera(float scaledSpeed)
    {
        camera.orthographicSize = Mathf.Lerp(minSize, maxSize, scaledSpeed);
    }
}
