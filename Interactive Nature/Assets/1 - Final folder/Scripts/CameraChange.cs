using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera ARCamera;
    public Camera UICamera;
    public Swiper swiper;
    public GameObject directional;

    // Call this function to disable AR camera,
    // and enable UI camera.

    void Update()
    {
        //Debug.Log("Swiper page" + swiper.currentPage);
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
    public void ShowUIView()
    {
        ARCamera.gameObject.SetActive(false);
        UICamera.gameObject.SetActive(true);
        //Debug.Log("UI should show");
    }

    // Call this function to enable AR camera,
    // and disable UI camera.
    public void ShowARView()
    {
        UICamera.gameObject.SetActive(false);
        ARCamera.gameObject.SetActive(true);
        //  Debug.Log("AR should show");
    }
}