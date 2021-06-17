using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintDisabled : MonoBehaviour
{
    //Disables and enables the visibility of the instruction screen 
    public GameObject button;
    void Start()
    {
        if (PlayerPrefs.GetInt("Hint") > 0)
        {
            transform.gameObject.SetActive(false);
            button.SetActive(true);
        }
        else
        {
            transform.gameObject.SetActive(true);
            button.SetActive(false);
        }
    }
}
