using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class InfoText : MonoBehaviour
{
    [Header("Text Names")]
    public Inspection inspection;

    public Swiper swiper;
    string readFromFilePath;
    List<string> fileLines;
    int counter = 0;


    public void updateValues()
    {
        if (inspection.myPlant != null)
        {
            readFromFilePath = Application.streamingAssetsPath + "/NectAR/" + inspection.myPlant.name + ".txt";

            fileLines = File.ReadAllLines(readFromFilePath).ToList();
        }
        
        int counter = 0;
        foreach (string line in fileLines)
        {
            if (line.Contains("end"))
            {
                return;
            }
            string[] x = line.Split('_');
            transform.GetChild(counter).GetChild(0).GetComponent<Text>().text = x[1];
            counter++;
        }
    }
}
