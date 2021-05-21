using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneIncrease : MonoBehaviour
{
    public GameObject cam;
    public float camScale;
    void Start()
    {
        cam = GameObject.Find("InspectionCamera");
    }

    // Update is called once per frame
    void Update()
    {
        camScale = cam.GetComponent<Camera>().orthographicSize;
        transform.localScale = new Vector3(camScale,camScale, (float)0.1);
    }
}
