using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTexture : MonoBehaviour
{
    static WebCamTexture backCamera;
    public static WebCamDevice targetCam;
    void Start()
    {
        if (backCamera == null)
        {
            backCamera = new WebCamTexture();
        }

        GetComponent<Renderer>().material.mainTexture = backCamera;

        if (!backCamera.isPlaying)
            backCamera.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
