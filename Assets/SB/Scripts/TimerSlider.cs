using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    Slider sliderTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        sliderTimer = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderTimer.value > 0.0f)
        {
            sliderTimer.value -= Time.deltaTime;
        }
        else
        {
            //Debug.Log("Time is Zero");
        }
    }
}
