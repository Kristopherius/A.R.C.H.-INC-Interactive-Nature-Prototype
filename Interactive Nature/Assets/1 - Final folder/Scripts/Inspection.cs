using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inspection : MonoBehaviour
{

    public GameObject myPlant;
    //public List<GameObject> Plants;
    private bool plantInstantiated = false;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeObject(GameObject plantToRotate)
    {
        myPlant = plantToRotate;
        myPlant.transform.parent = transform;
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "4 - Inspect Scene")
        {
            transform.position = GameObject.Find("Camera").transform.position;
            myPlant.transform.position = GameObject.Find("PlantPosition").transform.position;
            myPlant.AddComponent<MoveByTouch>();
        }
    }
}
