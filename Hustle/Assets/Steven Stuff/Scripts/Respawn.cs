using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    public GameObject currentCheckpoint;

    void OnColliderEnter(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("respawn");
            Destroy(other.gameObject.transform.parent);
            Instantiate(playerPrefab, new Vector2(currentCheckpoint.transform.position.x, currentCheckpoint.transform.position.y), Quaternion.identity);
            //put player's speed to the checkpoint's respawnSpeed value
        }
    }

}
