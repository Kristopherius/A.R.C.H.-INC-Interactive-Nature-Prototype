using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera ARCamera;
    public Camera UICamera;
    public Swiper swiper;
    public GameObject directional;

    

    void Update()
    {
        if (swiper.currentPage != 2)
        {
            ShowUIView();
            directional.SetActive(true);
        }
        else
        {
            ShowARView();
            directional.SetActive(false);
        }
    }
    
    // Call this function to disable AR camera,
    // and enable UI camera.

    public void ShowUIView()
    {
        ARCamera.gameObject.SetActive(false);
        UICamera.gameObject.SetActive(true);
    }

    // Call this function to enable AR camera,
    // and disable UI camera.

    public void ShowARView()
    {
        UICamera.gameObject.SetActive(false);
        ARCamera.gameObject.SetActive(true);
    }
}