using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonChange : MonoBehaviour
{
    GameObject myPlant;
    private void Start()
    {
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
        if (myPlant != null)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    public void changePlant(GameObject plant)
    {
        myPlant = plant;
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
