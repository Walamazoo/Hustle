using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] int respawnSpeed;
    [SerializeField] Respawn respawn;

    void OnColliderEnter(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("checkpoint");
            respawn.currentCheckpoint = gameObject;
        }
    }
}
