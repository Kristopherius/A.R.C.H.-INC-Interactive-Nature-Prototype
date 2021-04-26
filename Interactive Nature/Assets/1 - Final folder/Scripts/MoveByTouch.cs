using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveByTouch : MonoBehaviour
{

    private float rotationRate = 0.1f;
    public float zoomMin = 1;
    public float zoomMax = 14;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            float prevMagnitude = (touch0PrevPos - touch1PrevPos).magnitude;
            float currMagnitude = (touch0.position - touch1.position).magnitude;

            float difference = currMagnitude - prevMagnitude;

            zoom(difference * 0.1f);
        }
        else if (Input.touchCount == 1)
        {
            // get the user touch input
            foreach (Touch touch in Input.touches)
            {
                Debug.Log("Touching at: " + touch.position);

                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("Touch phase began at: " + touch.position);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Debug.Log("Touch phase Moved");
                    transform.Rotate(touch.deltaPosition.y * rotationRate,
                                     -touch.deltaPosition.x * rotationRate, 0, Space.World);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    Debug.Log("Touch phase Ended");
                }
            }
        }
        
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomMin, zoomMax);
    }

}