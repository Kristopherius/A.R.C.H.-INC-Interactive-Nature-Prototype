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
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LastValue", 0);


    }

    // Update is called once per frame
    void Update()
    {
        if (scanCheck.myPlant != null)
        {
            PlayerPrefSetter(scanCheck.myPlant);
        }
    }

    void PlayerPrefSetter(GameObject Plant)
    {
        if (!PlayerPrefs.HasKey("LastValue"))
        {
            PlayerPrefs.SetInt("LastValue", 0);
        }

        for (int i = 0; i < PlayerPrefs.GetInt("LastValue")+1; i++)
        {
            if(PlayerPrefs.GetInt("LastValue") == 0)
            {
                PlayerPrefs.SetString((PlayerPrefs.GetInt("LastValue")).ToString(), Plant.name);
                PlayerPrefs.SetInt("LastValue", 1);
                return;
            }
            else
            {
                if (PlayerPrefs.HasKey(i.ToString()))
                {
                    if (PlayerPrefs.GetString(i.ToString()) == Plant.name)
                    {
                        return;
                    }
                }
                else
                {
                    PlayerPrefs.SetString((PlayerPrefs.GetInt("LastValue")).ToString(), Plant.name);
                    PlayerPrefs.SetInt("LastValue", (PlayerPrefs.GetInt("LastValue") + 1));
                    return;
                    
                }
            }
        }

       
    }
}
