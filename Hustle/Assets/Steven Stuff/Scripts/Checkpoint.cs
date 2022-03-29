using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int respawnSpeed;
    [SerializeField] Respawn respawn;
    [SerializeField] int respawnIndex;
    private int _currentIndex = 0;

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("checkpoint");
            if(this.respawnIndex > _currentIndex){
                _currentIndex = this.respawnIndex;
                respawn.currentCheckpoint = this;
            }
        }
    }
}
