using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{

    /**
     
    Makes the AR Camera scaled to the size of the users screen
     
     */
    RectTransform rectT;
    void Start()
    {
        rectT = transform.GetComponent<RectTransform>();
    }

    void Update()
    {
        rectT.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}
