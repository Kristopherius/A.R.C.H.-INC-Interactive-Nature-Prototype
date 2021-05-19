using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inspection : MonoBehaviour
{

    public GameObject myPlant;
    public Swiper swiper;
    private float scale = 5f;
    public bool inFocus;

    public void ChangeObject(GameObject plantToRotate)
    {
        myPlant = plantToRotate;
    }

    public void Focused()
    {
        if (inFocus == true)
        {
            inFocus = false;
        }
        else
        {
            inFocus = true;
        }            
    }

    void Update()
    {
        if (myPlant != null & transform.childCount <= 0)
        {
            Instantiate(myPlant, transform);
            if (transform.childCount > 0)
            {
                foreach (Transform child in transform)
                {
                    if (child.GetComponent<MoveByTouch>() == null)
                    {
                        child.gameObject.SetActive(true);
                        child.transform.position = GameObject.Find("PlantPosition").transform.position;
                        child.transform.localScale = new Vector3(scale, scale, scale);
                        child.gameObject.AddComponent<MoveByTouch>();
                        child.gameObject.GetComponent<MoveByTouch>().enabled = false;
                    }
                }
            }
            
        }

        if(transform.childCount > 0)
        {
            if (inFocus)
            {
                if (transform.GetChild(0).GetComponent<MoveByTouch>() != null)
                {
                    Debug.Log("FOCUSED");
                    swiper.enabled = false;
                    transform.GetChild(0).gameObject.GetComponent<MoveByTouch>().enabled = true;
                }
            }
            else
            {
                Debug.Log("NOT FOCUSED");
                swiper.enabled = true;
                transform.GetChild(0).gameObject.GetComponent<MoveByTouch>().enabled = false;
            }
        }        
    }
}
