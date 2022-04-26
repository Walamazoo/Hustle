using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparks : MonoBehaviour
{
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        //particles.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Slide.is_sliding == true)
        {
            print("sliding");
            particles.enableEmission = true;
        }
        else
        {
            particles.enableEmission = false;
        }
        
    }
}
