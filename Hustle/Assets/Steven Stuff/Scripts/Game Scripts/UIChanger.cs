using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made with help from https://www.youtube.com/watch?v=gx0Lt4tCDE0

public class UIChanger : MonoBehaviour
{
    [SerializeField] GameObject[] rightArrows;
    [SerializeField] GameObject[] leftArrows;
    [SerializeField] GameObject GoldMedal;
    [SerializeField] GameObject SilverMedal;
    [SerializeField] GameObject BronzeMedal;
    [SerializeField] GameObject EndText;
    [SerializeField] GameObject Timer;
    private int _arrowIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnSpeedStateChange += UpdateUI;
        GameEvents.current.OnLevelCompleteChange += EndUI;
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

    private void EndUI(){
        float time = Timer.GetComponent<Timer>().time;
        float seconds = Mathf.FloorToInt(time % 60);
        if(seconds < 10f){
            GoldMedal.SetActive(true);
        }
        else if(seconds < 20f){
            SilverMedal.SetActive(true);
        }
        else{
            BronzeMedal.SetActive(true);
        }
        EndText.SetActive(true);
    }

}
