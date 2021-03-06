using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int totalPages = 3;
    public int currentPage = 2;
    public Vector3 inspectionPanel;


    /*
        Used the script from the tutorial of "Press Start" youtube channel
        https://www.youtube.com/watch?v=rjFgThTjLso
     */

    void Start()
    {
        panelLocation = transform.position;
        inspectionPanel = new Vector3(-540f, Screen.height/2f, 0f);
    }
    //added a function that allows the user to move directly to the inspection screen when tapping on a plant in the collection screen.
    public void moveToInspect()
    {
        StartCoroutine(SmoothMove(transform.position, inspectionPanel, easing));
        panelLocation = inspectionPanel;
        currentPage = 3;
    }

    public void OnDrag(PointerEventData data)
    {
        float differenceX = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(differenceX, 0, 0);
    }
    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage < totalPages)
            {
                currentPage++;
                newLocation += new Vector3(-Screen.width, 0, 0);
            }
            else if (percentage < 0 && currentPage > 1)
            {
                currentPage--;
                newLocation += new Vector3(Screen.width, 0, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}