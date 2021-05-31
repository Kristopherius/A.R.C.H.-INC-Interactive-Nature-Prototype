using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class InfoText : MonoBehaviour
{
    [Header("Text Names")]
    public Text Name;
    public Text Genus;
    public Text Family;
    public Text Kingdom;
    public Text Origin;
    public Text Height;
    public Text Season;
    public Text Medic;
    public Text Myth;
    public Inspection inspection;

    public Swiper swiper;
    string readFromFilePath;
    List<string> fileLines;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        readFromFilePath = Application.streamingAssetsPath + "/NectAR/" + "PlantInfo" + ".txt";

        fileLines = File.ReadAllLines(readFromFilePath).ToList();

        updateValues();

    }

    void updateValues()
    {
        int counter = 0;
        foreach (string line in fileLines)
        {
            if (inspection.myPlant != null && line.Contains(inspection.myPlant.tag))
            {
                if (line.Contains("end"))
                {
                    return;
                }
                string[] x = line.Split('_');
                transform.GetChild(counter).GetChild(0).GetComponent<Text>().text = x[1];
                counter++;
                //Debug.Log("Done " + counter + " times");
                
            }
            else
            {
                break;
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        updateValues();
        Debug.Log("Counter " + counter);
    }
}
