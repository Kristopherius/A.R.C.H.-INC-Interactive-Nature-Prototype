using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inspection : MonoBehaviour
{

    public GameObject myPlant;
    public Swiper swiper;

    public Transform pointA, pointB;
    public GameObject UIToMove;
    float speed = 1f;

    private float scale = 5f;

    public bool inFocus;

    public Quaternion initialRotation;

    public Vector3 zAngle;

    public void ChangeObject(GameObject plantToRotate)
    {
        myPlant = plantToRotate;
        initialRotation = myPlant.transform.rotation;
        DeleteChild();
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
        zAngle = new Vector3(0, 0, 1);
        Transform Button = UIToMove.transform.GetChild(0);

        if (!inFocus)
        {
            if (UIToMove.GetComponent<RectTransform>().position != pointA.position)
            {
                lerpUI(pointA);
            }

            if (Button.rotation != new Quaternion(0, 0, 270, 0))
            {
                Button.Rotate(zAngle, 270f);
            }
        }
        else
        {
            if (UIToMove.GetComponent<RectTransform>().position != pointB.position)
            {
                lerpUI(pointB);
            }

            if (Button.rotation == new Quaternion(0, 0, 90, 0))
            {
                Button.Rotate(zAngle, 180f);
            }
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

        if (transform.childCount > 0)
        {
            if (inFocus)
            {
                if (transform.GetChild(0).GetComponent<MoveByTouch>() != null)
                {
                    //Debug.Log("FOCUSED");
                    swiper.enabled = false;
                    transform.GetChild(0).gameObject.GetComponent<MoveByTouch>().enabled = true;
                }
            }
            else
            {
                //Debug.Log("NOT FOCUSED");
                swiper.enabled = true;
                transform.GetChild(0).gameObject.GetComponent<MoveByTouch>().enabled = false;
            }
        }
    }

    public void Reset()
    {
        
        if(transform.childCount > 0)
        {
            //Debug.Log("reset is pressed");
            transform.GetChild(0).transform.rotation = initialRotation;
        }
        else
        {
            //Debug.Log("reset is pressed but there's no children");
        }
    }
}
