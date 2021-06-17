using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonChange : MonoBehaviour
{
    GameObject myPlant;
    public Swiper swiper;
    public Inspection inspection;
    private void Start()
    {
        swiper = FindObjectOfType<Swiper>();
        inspection = FindObjectOfType<Inspection>();

        if(myPlant == null)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    //detects whether the user is on the inspection screen or not and allows them to change the seasons of the plant

    private void Update()
    {
        if (swiper.currentPage == 3 && inspection.transform.childCount > 0)
        {
            if (transform.name.Contains("Inspect"))
            {
                myPlant = inspection.transform.GetChild(0).gameObject;
                enableButtons();
            }
        }
    }

    //changes the plant based on the scanned plant
    public void changePlant(GameObject plant)
    {
        myPlant = plant;
        enableButtons();
    }
    //enables the season change buttons
    public void enableButtons()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
    //disables the season change buttons
    public void disableButtons()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    //changes the season based on the names of children of the scanned plant
    public void seasonChange(string season)
    {
        foreach(Transform child in myPlant.transform)
        {
            if (child.name.Contains(season))
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
