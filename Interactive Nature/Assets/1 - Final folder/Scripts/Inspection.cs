using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inspection : MonoBehaviour
{

    private GameObject myPlant;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeObject(GameObject plantToRotate)
    {
        myPlant = plantToRotate;
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "4 - Inspect Scene")
        {
            transform.Find("Plane").gameObject.SetActive(true);
            
            myPlant.SetActive(true);
        }
    }
}
