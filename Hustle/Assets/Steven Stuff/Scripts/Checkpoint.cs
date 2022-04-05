using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    public int respawnSpeed;
    [SerializeField] Respawn respawn;
    [SerializeField] int respawnIndex;
    [SerializeField] Timer timer;
    [SerializeField] TextMeshPro checkpointTimeText;
    private int _currentIndex = 0;
    

    void OnTriggerEnter2D(Collider2D other){
            Debug.Log("checkpoint");
            if(this.respawnIndex > _currentIndex){
                _currentIndex = this.respawnIndex;
                respawn.currentCheckpoint = this;

                float minutes = Mathf.FloorToInt(timer.time / 60); 
                float seconds = Mathf.FloorToInt(timer.time % 60);
                this.checkpointTimeText.text = string.Format("{0:00} {1:00}", minutes, seconds);
            }
    }
}
