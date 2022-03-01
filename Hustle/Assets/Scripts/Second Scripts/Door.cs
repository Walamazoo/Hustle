using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int doorID;
    [SerializeField] GameObject[] rightArrows;
    [SerializeField] GameObject[] leftArrows;
    private int _arrowIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.OpenDoorEvent += OpenDoor;
        EventManager.current.OnSpeedStateChange += UpdateUI;
    }

   private void OpenDoor(int triggerID){
       if(triggerID == doorID){
           Debug.Log("Open Door");
        }
    }

    private void UpdateUI(int direction){
        Debug.Log("Update UI");
        if(direction > 0){
            if(_arrowIndex >= 0 && _arrowIndex < 3){
                rightArrows[_arrowIndex].SetActive(true);
                _arrowIndex += direction;
            }
            else if(_arrowIndex <= 0 && _arrowIndex > -4){
                _arrowIndex += direction;
                leftArrows[Mathf.Abs(_arrowIndex)].SetActive(false);
            }
        }

        else{
            if(_arrowIndex <= 0 && _arrowIndex > -3){
                leftArrows[Mathf.Abs(_arrowIndex)].SetActive(true);
                _arrowIndex += direction;
            }
            else if(_arrowIndex >= 0 && _arrowIndex < 4){
                _arrowIndex += direction;
                rightArrows[_arrowIndex].SetActive(false);
            }
        }
    }

    private void OnDisable(){
        EventManager.current.OpenDoorEvent -= OpenDoor;
    }
}
