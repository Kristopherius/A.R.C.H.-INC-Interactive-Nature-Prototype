using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{

    public Inspection scanCheck; 

    // Start is called before the first frame update
    void Start()
    {
        scanCheck = FindObjectOfType<Inspection>();
        Debug.Log(scanCheck.varA);
        //Debug.Log(scanCheck.myPlant.tag + " This is my plant");

    }

    // Update is called once per frame
    void Update()
    {
        if (scanCheck.myPlant != null)
        {
            Debug.Log("This means it is not null"); // check wich plant is being scanned

            if (scanCheck.myPlant.tag == "Vulgare")
            {
                Debug.Log("Vulgare"); // set playerprefs here? or create seperate script for that?
                PlayerPrefs.SetInt("vulgare", 5);

                int score = PlayerPrefs.GetInt("vulgare");
                Debug.Log(score);
            }
            else if (scanCheck.myPlant.tag == "Verbena")
            {
                Debug.Log("Verbena");

                PlayerPrefs.SetInt("verbena", 66);

                
                
            }
            /*else if (scanCheck.myPlant.tag == "Vulgare")
            {
                Debug.Log("testiiinnngggg");
            }
            else if (scanCheck.myPlant.tag == "Vulgare")
            {
                Debug.Log("testiiinnngggg");
            }
            else if (scanCheck.myPlant.tag == "Vulgare")
            {
                Debug.Log("testiiinnngggg");
            else if (scanCheck.myPlant.tag == "Vulgare")
            {
                Debug.Log("testiiinnngggg");
            }
            else if (scanCheck.myPlant.tag == "Vulgare")
            {
                Debug.Log("testiiinnngggg");
            }
            else if (scanCheck.myPlant.tag == "Vulgare")
            {
                Debug.Log("testiiinnngggg");
            }*/
        }
    }
}
