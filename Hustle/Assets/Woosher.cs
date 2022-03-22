using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woosher : MonoBehaviour
{

    public AnimationCurve pitchChange, volumeChange; // pitch and volume change over percentages of the max speed
    public float smoothing = 1f;

    AudioSource woosh;

    // Start is called before the first frame update
    void Start()
    {
        woosh = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateWooshing(float scaledSpeed)
    {
        float targetPitch = pitchChange.Evaluate(scaledSpeed);
        float targetVolume = volumeChange.Evaluate(scaledSpeed);

        woosh.pitch = Mathf.Lerp(woosh.pitch, targetPitch, Time.deltaTime * smoothing);
        woosh.volume = Mathf.Lerp(woosh.volume, targetVolume, Time.deltaTime * smoothing);
        
    }
}
