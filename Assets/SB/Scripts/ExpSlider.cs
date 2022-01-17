using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpSlider : MonoBehaviour
{
    public Slider sliderExp;
 
    // Start is called before the first frame update
    void Start()
    {
        Slider sliderExp = GetComponent<Slider>();
        sliderExp.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderExp.value <= 0)
        {
            transform.Find("Fill Area").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("Fill Area").gameObject.SetActive(true);
        }

        
    }

    public void OnClickComplete()
    {
        sliderExp.value = ScoreManager.Instance.exp;
    }
}
