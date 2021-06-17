using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inspection : MonoBehaviour
{
    [Header("Plant Inspection")]
    public GameObject myPlant;
    public Swiper swiper;

    [Header("UI Properties")]
    public Transform pointA;
    public Transform pointB;
    public GameObject UIToMove;
    public bool inFocus;
    public Vector3 buttonScale;
    public Color colorGreen;
    public Color colorBrown;
    float speed = 1f;
    public Text plantName;

    [Header("Reset Function")]
    private float scale = 5f;
    public Quaternion initialRotation;

    [Header("Seasonal Rotation")]
    public int counter = 0;


    //Instantiate the color values for the button change
    //It gave some errors in the past if i didnt instantiate it in the start function
    private void Start()
    {
        colorGreen = new Color32(173, 193, 120, 255);
        colorBrown = new Color32(108, 88, 76, 255);
    }

    //Allows the image targets from AR view to update the plant object in the inspection screen.
    public void ChangeObject(GameObject plantToRotate)
    {
        myPlant = plantToRotate;
        switchOnRender();
        initialRotation = myPlant.transform.rotation;
        DeleteChild();
        
    }


    /*
     * Vuforia switches on/off the MeshRenderer whenever a plant is scanned or out of view
     * which caused the plants cloned to not render which is why this function is callled whenever the plant is spawned in the Inspection screen
     * 
     */
    void switchOnRender()
    {
        GameObject plant = null;
        if (transform.childCount > 0)
        {
            plant = gameObject.transform.GetChild(0).gameObject;
        }
        if (plant != null)
        {
            for (int i = 0; i < plant.GetComponentsInChildren<MeshRenderer>().Length; i++)
            {
                plant.GetComponentsInChildren<MeshRenderer>()[i].enabled = true;
            }
        }
    }
    
    //Sets the inFocus boolean to true or false - responsible for moving the ui up and down on the inspection screen
    
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

    // Whenever a new plant is chosen for the inspection screen it gets duplicated as a child of the InspectionManager object
    // and this function deletes the child that is already there whenever a new plant is scanned
    
    public void DeleteChild()
    {
        if (myPlant != null && transform.childCount > 0)
        {
            if (myPlant.tag != transform.GetChild(0).tag)
            {
                foreach (Transform child in transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
        }

    }

    //function that lerps the ui from it's current position to a set pointA position

    void lerpUI(Transform pointA)
    {
        speed = 10 * Time.deltaTime;
        UIToMove.gameObject.transform.position = Vector3.Lerp(UIToMove.gameObject.transform.position, pointA.position, speed);
    }
    //using the fixedUpdate function for a smooth movement of the UI based on the inFocus movement
    void FixedUpdate()
    {
        buttonScale = new Vector3(1, 1, 1);
        Transform Button = UIToMove.transform.GetChild(0);

        if (!inFocus)
        {
            if (UIToMove.GetComponent<RectTransform>().position != pointA.position)
            {
                lerpUI(pointA);
            }

            Button.localScale = buttonScale;
            UIToMove.GetComponentInChildren<Image>().color = colorBrown;
        }
        else
        {
            if (UIToMove.GetComponent<RectTransform>().position != pointB.position)
            {
                lerpUI(pointB);
            }

            Button.localScale = -buttonScale;
            UIToMove.GetComponentInChildren<Image>().color = colorGreen;
        }
    }
    
    void Update()
    {
        //if the user is looking at the inspection screen the app will have it's mesh renderer switched on
        if(swiper.currentPage == 3)
        {
            switchOnRender();
        }
        //creates a child of the plant that was just scanned
        if (myPlant != null & transform.childCount <= 0)
        {
            Instantiate(myPlant, transform);
            plantName.text = myPlant.name;

            if (transform.childCount > 0)
            {
                foreach (Transform child in transform)
                {
                    //adds the moveByTouch script to the inspected plant for allowing moving the plant
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

        if (transform.childCount > 0)
        {
            if (inFocus)
            {
                //switches of the swiping and switches on the moving of the plant
                if (transform.GetChild(0).GetComponent<MoveByTouch>() != null)
                {
                    swiper.enabled = false;
                    transform.GetChild(0).gameObject.GetComponent<MoveByTouch>().enabled = true;
                }
            }
            else
            {
                swiper.enabled = true;
                transform.GetChild(0).gameObject.GetComponent<MoveByTouch>().enabled = false;
            }
        }
    }
    //allows for reseting the position of the plant
    public void Reset()
    {
        if(transform.childCount > 0)
        {
            transform.GetChild(0).transform.rotation = initialRotation;
        }
        else
        {
            Debug.Log("reset is pressed but there's no children");
        }
    }
}
