using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyBillboarder : MonoBehaviour
{

    public float speedFactor = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, -1*transform.position.x*speedFactor, 0)); //spin around based on x position
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}
