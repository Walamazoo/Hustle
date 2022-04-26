using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

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
    [SerializeField] GameEvents stateHolder;

    float time;
    TextMeshProUGUI endtext;
    public int Level;
    string[] lines;
    string path;
    //private int _arrowIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnSpeedStateChange += UpdateUI;
        GameEvents.current.OnLevelCompleteChange += EndUI;
        time = Timer.GetComponent<Timer>().time;
        endtext = EndText.GetComponent<TextMeshProUGUI>();
    }

    private void UpdateUI(int direction){
        Debug.Log("Update UI");
        if(direction > 0){
            if(stateHolder.speedState >= 0 && stateHolder.speedState < 3){
                rightArrows[stateHolder.speedState].SetActive(true);
                stateHolder.speedState += direction;
            }
            else if(stateHolder.speedState <= 0 && stateHolder.speedState > -4){
                stateHolder.speedState += direction;
                leftArrows[Mathf.Abs(stateHolder.speedState)].SetActive(false);
            }
        }

        else{
            if(stateHolder.speedState <= 0 && stateHolder.speedState > -3){
                leftArrows[Mathf.Abs(stateHolder.speedState)].SetActive(true);
                stateHolder.speedState += direction;
            }
            else if(stateHolder.speedState >= 0 && stateHolder.speedState < 4){
                stateHolder.speedState += direction;
                rightArrows[stateHolder.speedState].SetActive(false);
            }
        }
    }

    private void EndUI(){
        time = Timer.GetComponent<Timer>().time;
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

        path = Application.dataPath + "/Aidan Stuff/" + "SavedTimes.txt";
        lines = File.ReadAllLines(path);
        float timeToCompare = float.Parse(lines[LevelNumber], CultureInfo.InvariantCulture.NumberFormat);
        if(time < timeToCompare && timeToCompare != 0.0f){
            lines[Level] = time.ToString();
        }
        File.WriteAllLines(path, lines);
    }

}
