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
    public void changePlant(GameObject plant)
    {
        myPlant = plant;
        enableButtons();
    }

    public void enableButtons()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void disableButtons()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

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
