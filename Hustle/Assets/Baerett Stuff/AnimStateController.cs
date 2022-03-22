using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AnimStateController: MonoBehaviour
{
    Animator animator;
    CameraZoomer zoomer;
    Woosher woosher;
    Player player;
    readonly static float maxSpeed = 15f;     // the speed at which we're at our "fastest" animation. Hardcoded for now, this is the highest x velocity the Player object reaches 
    

    /// <summary>
    /// The maximum and minimum speed modifiers for animations. Animations will get faster or slower based on actual speed, but these values clamp
    /// that to ensure we're not, like, sliding in slow motion or anything.
    /// </summary>
    static float maxAnimSpeedMod = 3f;
    static float minAnimSpeedMod = 0.75f;


    int level = 0;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        GameEvents.current.OnSpeedStateChange += Current_OnSpeedStateChange;
        player = GetComponentInParent<Player>();
        zoomer = Camera.main.GetComponent<CameraZoomer>();
        woosher = Camera.main.GetComponent<Woosher>();
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
        
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown("down"))
            animator.SetTrigger("Slide");
        


        if (Input.GetKey(KeyCode.S) || Input.GetKeyDown("down"))
            animator.SetBool("SlideHeld", true);
        else animator.SetBool("SlideHeld", false);

        float scaledSpeed = Mathf.Abs(player.velocity.x) / maxSpeed;

        updateBody(scaledSpeed, level); // pass in physical values for animation

        zoomer.updateCamera(scaledSpeed);
        woosher.updateWooshing(scaledSpeed);
    }


    /// <summary>
    /// Tells the animator component important values like speed, and maintains the right character rotation (about y axis).
    /// </summary>
    /// <param name="scaledSpeed"> Speed as represented by a decimal value between 0 and 1, with 0 being stopped and 1 being full speed. Used for animation blending. </param>
    /// <param name="targetLevel"> The current target level (of speed).</param>
    void updateBody(float scaledSpeed, int targetLevel)
    {
        //transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(0, (currentSpeed < 0 ? 1 : -1) * maxAngle, Mathf.Abs(currentSpeed) / 3));   //LEANING FORWARD W/ SPEED

        if (targetLevel < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        else if(targetLevel != 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        animator.SetFloat("Speed", scaledSpeed);
        animator.SetFloat("AnimSpeedMod", getAnimSpeedMod(scaledSpeed));
    }


    float getAnimSpeedMod(float scaledSpeed)
    {
        // more code will go here later, probably involving an animation curve. For now, we're doing a simple clamp.
        return Mathf.Clamp(scaledSpeed, minAnimSpeedMod, maxAnimSpeedMod); 
    }

    private void FixedUpdate()
    {

    }

}
