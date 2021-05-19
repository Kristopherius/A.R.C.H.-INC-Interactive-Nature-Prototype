using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public Inspection plantTransform;
    public Vector3 startPosition;

    private void Awake()
    {
        startPosition = new Vector3(0,0,0);
    }
    // Start is called before the first frame update
    void Start()
    {
        plantTransform = FindObjectOfType<Inspection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        plantTransform.myPlant.transform.position = startPosition;
    }
}
