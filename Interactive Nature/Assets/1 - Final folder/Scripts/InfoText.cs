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

    string[] lines;


    public void updateValues()
    {
        if (inspection.myPlant != null)
        {
            TextAsset fileToRead = Resources.Load<TextAsset>(inspection.myPlant.name);
            lines = fileToRead.text.Split('\n');
        }
        
        int counter = 0;
        foreach (string line in lines)
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
