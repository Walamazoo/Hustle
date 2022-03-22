using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    Camera camera;

    public float minSize, maxSize;
    public AnimationCurve sizeChange;
    public float smoothing = 1;

    int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        GameEvents.current.OnSpeedStateChange += Current_OnSpeedStateChange;
    }

    private void Current_OnSpeedStateChange(int direction)
    {
        state += direction;
        if (state < -3) state = -3;
        if (state > 3) state = 3;

    }

    // Update is called once per frame
    void Update()
    {
        //camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, sizeChangePerLevel.Evaluate(camera.orthographicSize))   
    }

    public void updateCamera(float scaledSpeed)
    {
        //camera.orthographicSize = Mathf.Lerp(minSize, maxSize, scaledSpeed);
        float targetSize = Mathf.Lerp(minSize, maxSize, sizeChange.Evaluate(scaledSpeed));
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetSize, Time.deltaTime * smoothing);
    }
}
