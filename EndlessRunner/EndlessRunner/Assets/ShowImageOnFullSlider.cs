using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImageOnFullSlider : MonoBehaviour
{

    public Slider slider;
    public Image image;
    private void Update()
    {
        if(slider.value >= slider.maxValue)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false; 
        }
    }
}
