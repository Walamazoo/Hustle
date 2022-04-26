using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveTimeWriter : MonoBehaviour
{
    public int Level;
    string[] lines;
    string path;
    string fileName;

    // Start is called before the first frame update
    void Start()
    {
        fileName = "SavedTimes.txt";
        path = Application.dataPath + "/Aidan Stuff/" + "SavedTimes.txt";
        lines = File.ReadAllLines(path);
        lines[Level] = "Yes yes yes";
        File.WriteAllLines(path, lines);
    }

    
}
