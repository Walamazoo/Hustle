using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AnimStateController: MonoBehaviour
{
    Animator animator;


    Player player;
    readonly static float maxSpeed = 10f;     // the speed at which we're at our "fastest" animation. Hardcoded for now, this is the highest x velocity the Player object reaches 
    public float maxAngle = 20;

    int level = 0;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        GameEvents.current.OnSpeedStateChange += Current_OnSpeedStateChange;
        player = GetComponentInParent<Player>();
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

        updateBody(Mathf.Abs(player.velocity.x)/maxSpeed, level); // pass in physical values for animation
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
