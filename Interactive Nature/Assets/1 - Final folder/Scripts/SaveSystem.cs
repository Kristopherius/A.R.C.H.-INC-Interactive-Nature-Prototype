using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{

    public Inspection scanCheck;
    public Swiper swiper;

    private bool collCheckRan = false;


    // Start is called before the first frame update
    void Start()
    {
        scanCheck = FindObjectOfType<Inspection>();
        swiper = FindObjectOfType<Swiper>();
        CollectionCheck();
    }

    // Update is called once per frame
    void Update()
    {
        if (scanCheck.myPlant != null)
        {
            PlayerPrefSetter(scanCheck.myPlant);
        }

        if(swiper.currentPage == 1 && collCheckRan == false)
        {
            collCheckRan = true;
            CollectionCheck();
        }

        if(swiper.currentPage != 1)
        {
            collCheckRan = false;
        }
    }

    //Function that reads through the current PlayerPrefs in case the developer needs to check them

    void PrefReader()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("LastValue"); i++)
        {
            Debug.Log(i + " - " + (PlayerPrefs.GetString(i.ToString())));
        }
    }

    //Function that checks the current player prefs and updates the collection screen with the plants that are currently "owned"

    public void CollectionCheck()
    {
        foreach(Transform child in transform)
        {
            if (PlayerPrefs.GetInt("LastValue") > 0)
            {
                for (int i = 0; i < PlayerPrefs.GetInt("LastValue"); i++)
                {
                    if (child.name != PlayerPrefs.GetString(i.ToString()))
                    {
                        //add functionality for the disabled collection object
                        child.GetComponentInChildren<Text>().enabled = false;
                        child.GetComponent<Button>().enabled = false;
                        child.GetComponent<RawImage>().color = Color.black * 0.39f;
                    }
                    else
                    {
                        //add functionality for the enabled collection object
                        child.GetComponent<RawImage>().color = Color.white;
                        child.GetComponent<Button>().enabled = true;
                        child.GetComponentInChildren<Text>().enabled = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    child.GetComponentInChildren<Text>().enabled = false;
                    child.GetComponent<Button>().enabled = false;
                    child.GetComponent<RawImage>().color = Color.black * 0.39f;
                }
            }            
        }        
    }

    //Deletes all player prefs
    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LastValue", 0);
        CollectionCheck();
    }
    //Sets the Hint playerpref to on or off so it doesnt show up with every app launch
    public void hintDisabled()
    {
        PlayerPrefs.SetInt("Hint",1);
    }

    //Sets the PlayerPrefs based on the current scanned plant
    void PlayerPrefSetter(GameObject Plant)
    {
        if (!PlayerPrefs.HasKey("LastValue"))
        {
            PlayerPrefs.SetInt("LastValue", 0);
        }

        for (int i = 0; i < PlayerPrefs.GetInt("LastValue") + 1; i++)
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
