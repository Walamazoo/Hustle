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
    [SerializeField] GameObject flag;
    private int _currentIndex = -1;

    [SerializeField] GameObject[] splitBacks;
    [SerializeField] TextMeshPro[] speedrunTimeTexts;
    [SerializeField] TextMeshPro[] speedrunSplitTexts;

    void OnTriggerEnter2D(Collider2D other){
            //Debug.Log("checkpoint");
            if(this.respawnIndex > _currentIndex){
                _currentIndex = this.respawnIndex;
                respawn.currentCheckpoint = this;

                flag.SetActive(true);
                float minutes = Mathf.FloorToInt(timer.time / 60); 
                float seconds = Mathf.FloorToInt(timer.time % 60);
                this.checkpointTimeText.text = string.Format("{0:00} {1:00}", minutes, seconds);

                speedrunTimeTexts[respawnIndex].text = string.Format("{0:00}:{1:00}", minutes, seconds);

                if(timer.checkpointTimes[respawnIndex] == 0){
                    timer.checkpointTimes[respawnIndex] = timer.time;
                }
                else{
                    float split = timer.time - timer.checkpointTimes[respawnIndex]; 
                    timer.checkpointTimes[respawnIndex] = timer.time;
                    //float splitMinutes = Mathf.FloorToInt(split / 60); 
                    float splitSeconds = Mathf.FloorToInt(split % 60);
                    if(split > 0){
                        speedrunSplitTexts[respawnIndex].text = "+" + splitSeconds.ToString();
                        speedrunSplitTexts[respawnIndex].color = Color.red;
                    }
                    else if(split < 0){
                        speedrunSplitTexts[respawnIndex].text = splitSeconds.ToString();
                        speedrunSplitTexts[respawnIndex].color = Color.green;
                    }
                    else{
                        speedrunSplitTexts[respawnIndex].text = splitSeconds.ToString();
                        speedrunSplitTexts[respawnIndex].color = Color.yellow;
                    }
                }

                foreach (GameObject back in splitBacks){
                        back.SetActive(false);
                }
                if(respawnIndex < splitBacks.Length){
                     splitBacks[respawnIndex+1].SetActive(true);
                }
            }
    }
}
