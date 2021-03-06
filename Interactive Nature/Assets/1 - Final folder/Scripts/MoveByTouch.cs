using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveByTouch : MonoBehaviour
{
    
    private float rotationRate = 0.1f;

    public float zoomMin = 0.2f;
    public float zoomMax = 2.5f;

    public GameObject cam;

    private void Start()
    {
        cam = GameObject.Find("InspectionCamera");
    }

    void Update()
    {
        //move the plant based on the touch input on the inspection screen
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            float prevMagnitude = (touch0PrevPos - touch1PrevPos).magnitude;
            float currMagnitude = (touch0.position - touch1.position).magnitude;

            float difference = currMagnitude - prevMagnitude;
            zoom(difference * 0.01f);
        }
        else if (Input.touchCount == 1)
        {
            // get the user touch input
            foreach (Touch touch in Input.touches)
            {
                //Debug.Log("Touching at: " + touch.position);

                if (touch.phase == TouchPhase.Began)
                {
                    //Debug.Log("Touch phase began at: " + touch.position);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    transform.Rotate(touch.deltaPosition.y * rotationRate, -touch.deltaPosition.x * rotationRate, 0, Space.World);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    //Debug.Log("Touch phase Ended");
                }
            }
        }

    }

    //increase the orthographicSize of the main camera when inspecting a plant based on an increment

    void zoom(float increment)
    {
        cam.GetComponent<Camera>().orthographicSize = Mathf.Clamp(cam.GetComponent<Camera>().orthographicSize - increment, zoomMin, zoomMax);
    }

}