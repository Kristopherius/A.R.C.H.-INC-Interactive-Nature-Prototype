using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class SliderManager : MonoBehaviour
{
    public Slider mySlider;
    private GameObject myPlant;
    private float previousValue;
    
    public void ChangeName(GameObject plantToRotate)
    {
        myPlant = plantToRotate;
    }
    void Awake()
    {
        // Assign a callback for when this slider changes
        this.mySlider.onValueChanged.AddListener(this.OnSliderChanged);

        // And current value
        this.previousValue = this.mySlider.value;
    }

    void OnSliderChanged(float value)
    {
        // How much we've changed
        float delta = value - this.previousValue;
        this.myPlant.transform.Rotate(Vector3.up * delta * 360);

        // Set our previous value for the next change
        this.previousValue = value;
    }
}

