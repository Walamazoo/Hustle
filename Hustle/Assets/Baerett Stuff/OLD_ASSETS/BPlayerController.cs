using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BPlayerController : MonoBehaviour
{
    public float speedPerLevel = 1f;

    public int level = 0;
    public float currentSpeed = 0;
    public float scaledSpeed = 0;

    public float sinceGearChange = 0;

    public AnimationCurve accelerationCurve;

    Animator animator;

    AnimStateController body;
    CameraZoomer zoomer;
    public SpeedIndicatorGroup indicatorGroup;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponentInChildren<AnimStateController>();
        zoomer = GetComponentInChildren<CameraZoomer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.D))
        {
            level += 1;
            sinceGearChange = 0;
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            level -= 1;
            sinceGearChange = 0;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            level = 0;
            sinceGearChange = 0;
        }

        if (currentSpeed != (speedPerLevel * level))
        {
            currentSpeed = Mathf.Lerp(currentSpeed, speedPerLevel * level, accelerationCurve.Evaluate(sinceGearChange));
            scaledSpeed = Mathf.Abs(currentSpeed) / (3 * speedPerLevel);
            sinceGearChange += Time.deltaTime;
        }
        


        if (level > 3) level = 3;
        if (level < -3) level = -3;

        body.updateBody(scaledSpeed, level);
        zoomer.updateCamera(scaledSpeed);
        indicatorGroup.updateIndicators(scaledSpeed, level);
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(currentSpeed, 0, 0);    
    }
}
