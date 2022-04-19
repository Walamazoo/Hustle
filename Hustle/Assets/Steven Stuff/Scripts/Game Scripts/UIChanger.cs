using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [SerializeField] float GoldTimer;
    [SerializeField] float SilverTimer;
    [SerializeField] GameObject button;

    float time;
    TextMeshProUGUI endtext;
    private int _arrowIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnSpeedStateChange += UpdateUI;
        GameEvents.current.OnLevelCompleteChange += EndUI;
        float time = Timer.GetComponent<Timer>().time;
        TextMeshProUGUI endtext = EndText.GetComponent<TextMeshProUGUI>();
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
        float seconds = Mathf.FloorToInt(time % 60);
        float minutes = Mathf.FloorToInt(time / 60); 
        string timetext = string.Format("{0:00} : {1:00}", minutes, seconds);
        string goldtime = string.Format("{0:00} : {1:00}", Mathf.FloorToInt(GoldTimer / 60), Mathf.FloorToInt(GoldTimer % 60));
        string silvertime = string.Format("{0:00} : {1:00}", Mathf.FloorToInt(SilverTimer / 60), Mathf.FloorToInt(SilverTimer % 60));
        if(time <= GoldTimer){
            GoldMedal.SetActive(true);
            endtext.text = "Your time was: " + timetext + "\n" +
                            "You Got The Gold Medal! \n" +
                            "Congratulations!";
        }
        else if(time <= SilverTimer){
            SilverMedal.SetActive(true);
            endtext.text = "Your time was: " + timetext + "\n" +
                            "You Got The Silver Medal \n" +
                            "In Order To Get Gold You Needed: " + goldtime;
        }
        else{
            BronzeMedal.SetActive(true);
            endtext.text = "Your time was: " + timetext + "\n" +
                            "You Got The Bronze Medal \n" +
                            "In Order To Get Silver You Needed: " + silvertime;
        }
        EndText.SetActive(true);
        button.SetActive(true);
    }

}
