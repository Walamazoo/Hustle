using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIndicatorGroup : MonoBehaviour
{
    int currentLevel = 0;
    SpriteRenderer currentRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateIndicators(float currentSpeed, int targetLevel)
    {
        // selecting indicator child (hacky!)
        int childIndex = targetLevel + 3;
        for(int i = 0; i < transform.childCount; i++)
        {
            SpriteRenderer renderer = transform.GetChild(i).GetComponent<SpriteRenderer>();
            if(i == childIndex)
            {
                renderer.color = new Color(1, 1, 1, 1);
            }
            else
            {
                renderer.color = new Color(1, 1, 1, 0.5f);

            }
        }

    }
}
