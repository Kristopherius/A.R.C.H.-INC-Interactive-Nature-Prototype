using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inspection : MonoBehaviour
{
    // part of testing the SaveSystem.
    public int varA;

    public GameObject myPlant;
    private GameObject otherInspect;

    private void Start()
    {
        otherInspect = GameObject.Find("InspectManager");
        if(otherInspect != this.gameObject)
        {
            Destroy(otherInspect);
        }
    }
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
        // part of testing the SaveSystem.
        varA = PlayerPrefs.GetInt("verbena");
        
        if (SceneManager.GetActiveScene().name == "3 - Base Scene" && transform.childCount <= 0)
        {
            if (myPlant != null) { Instantiate(myPlant, transform); }


            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        if (SceneManager.GetActiveScene().name == "4 - Inspect Scene")
        {
            foreach (Transform child in transform)
            {
                if(child.GetComponent<MoveByTouch>() == null)
                {
                    child.gameObject.SetActive(true);
                    child.transform.position = GameObject.Find("PlantPosition").transform.position;
                    child.transform.localScale = new Vector3(25f, 25f, 25f);
                    child.gameObject.AddComponent<MoveByTouch>();
                }
            }
        }
    }
}
