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


    public void updateValues()
    {
        readFromFilePath = Application.dataPath;
        Debug.Log("dataPath : " + readFromFilePath);
        if (inspection.myPlant != null)
        {
            //readFromFilePath = Application.streamingAssetsPath + "/NectAR/" + inspection.myPlant.name + ".txt";
            readFromFilePath = Application.dataPath;

            fileLines = File.ReadAllLines(readFromFilePath).ToList();
        }
        
        int counter = 0;
        foreach (string line in fileLines)
        {
            if (line.Contains("@?!@"))
            {
                return;
            }
            
            transform.GetChild(counter).GetChild(0).GetComponent<Text>().text = line;
            counter++;
        }
    }
}
