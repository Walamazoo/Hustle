using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AnimStateController: MonoBehaviour
{
    Animator animator;

    public float maxSpeed = 3f; // max speed in meters per second. Currently, we're using this for standalone flexability of the animation rig (fully decoupled).
    public float maxAngle = 20;

    int level = 0;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        GameEvents.current.OnSpeedStateChange += Current_OnSpeedStateChange;
    }


    // very subject to change

    /// <summary>
    /// Catches the <c>OnSpeedStateChange</c> event from <c>GameEvents</c> and uses it to update our animation system.
    /// </summary>
    /// <param name="dir">Either 1 or -1, based on the change of "gear".</param>
    private void Current_OnSpeedStateChange(int dir)
    {
        level += dir;

        // this should be handled in GameEvents
        if (level < -3) level = -3;
        if (level > 3) level = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // TEMPORARY!! Need changes from event system before I can make speed changes gradual.
        // Have to be able to access our speed, probably.
        updateBody(3 / Mathf.Abs(level), level);
    }


    /// <summary>
    /// Tells the animator component important values like speed, and maintains the right character rotation (about y axis).
    /// </summary>
    /// <param name="scaledSpeed"> Speed as represented by a decimal value between 0 and 1, with 0 being stopped and 1 being full speed. Used for animation blending. </param>
    /// <param name="targetLevel"> The current target level (of speed).</param>
    public void updateBody(float scaledSpeed, int targetLevel)
    {
        //transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(0, (currentSpeed < 0 ? 1 : -1) * maxAngle, Mathf.Abs(currentSpeed) / 3));   //LEANING FORWARD W/ SPEED

        if (targetLevel < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        else if(targetLevel != 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        animator.SetFloat("Speed", scaledSpeed);
    }

    private void FixedUpdate()
    {
        
    }

}
