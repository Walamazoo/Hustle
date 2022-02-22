using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made with help from https://www.youtube.com/watch?v=gx0Lt4tCDE0

public class UIChanger : MonoBehaviour
{
    [SerializeField] GameObject[] rightArrows;
    [SerializeField] GameObject[] leftArrows;
    private int _arrowIndex = 0;

    private void start(){
        GameEvents.current.OnSpeedStateChange += UpdateUI;
    }

    private void UpdateUI(int direction){
        Debug.Log("Update UI");
        if(direction > 0){
            if(_arrowIndex >= 0 && _arrowIndex < 4){
                rightArrows[_arrowIndex].SetActive(true);
                _arrowIndex += direction;
            }
            else if(_arrowIndex <= 0 && _arrowIndex > -4){
                leftArrows[Mathf.Abs(_arrowIndex)].SetActive(false);
                _arrowIndex += direction;
            }
        }

        else{
            if(_arrowIndex <= 0 && _arrowIndex > -4){
                leftArrows[Mathf.Abs(_arrowIndex)].SetActive(true);
                _arrowIndex += direction;
            }
            else if(_arrowIndex >= 0 && _arrowIndex < 4){
                rightArrows[_arrowIndex].SetActive(false);
                _arrowIndex += direction;
            }
        }
    }
}
