using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rectT;
    void Start()
    {
        //Debug.Log("Camera Testing - Screen Width " + Screen.width);
        //Debug.Log("Camera Testing - Screen Height " + Screen.height);
        rectT = transform.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectT.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}
