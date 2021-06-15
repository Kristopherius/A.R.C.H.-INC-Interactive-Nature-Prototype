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



    private void Start()
    {
        colorGreen = new Color32(173, 193, 120, 255);
        colorBrown = new Color32(108, 88, 76, 255);
}
    public void ChangeObject(GameObject plantToRotate)
    {
        myPlant = plantToRotate;
        switchOnRender();
        initialRotation = myPlant.transform.rotation;
        DeleteChild();
        
    }

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

    public void rotateSeasonsV1()
    {
        if (transform.GetChild(0) != null)
        {
            GameObject go = transform.GetChild(0).gameObject;
            go.transform.GetChild(counter).gameObject.SetActive(true);

            foreach(Transform child in go.transform)
            {
                for (int i = 0; i < go.GetComponentsInChildren<MeshRenderer>().Length; i++)
                {
                    go.GetComponentsInChildren<MeshRenderer>()[i].enabled = true;
                }
                if(child != go.transform.GetChild(counter))
                {
                    child.gameObject.SetActive(false);
                }
            }
            counter++;
            if (counter >= go.transform.childCount)
            {
                counter = 0;
            }
        }
    }

    public void rotateSeasonsV2(string seasonName)
    {

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

    void lerpUI(Transform pointA)
    {
        speed = 10 * Time.deltaTime;
        UIToMove.gameObject.transform.position = Vector3.Lerp(UIToMove.gameObject.transform.position, pointA.position, speed);
    }

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
        if(swiper.currentPage == 3)
        {
            switchOnRender();
        }

        if (myPlant != null & transform.childCount <= 0)
        {
            Instantiate(myPlant, transform);
            plantName.text = myPlant.name;

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

        if (transform.childCount > 0)
        {
            if (inFocus)
            {
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
