using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recipeTimer : MonoBehaviour
{
    public Slider sliderRecipeTimer;
    // Start is called before the first frame update
    void Start()
    {
        Slider sliderRecipeTimer = GetComponent<Slider>();
        sliderRecipeTimer.value = 10;
    }

    // Update is called once per frame
    void Update()
    {

        if (sliderRecipeTimer.value > 0.0f)
        {
            sliderRecipeTimer.value -= Time.deltaTime;
        }
        else if (sliderRecipeTimer.value > 0.0f && sliderRecipeTimer.value <= 5.0f)
        {
            // 레시피 제한시간이 절반이상 지나면
            // 손님이 살짝 화내는 이펙트
        }
        else
        {
            // 레시피 제한시간이 다 되면
            // 손님이 화내는 이펙트 
        }
    }

    public void OnClickComplete()
    {
        sliderRecipeTimer.value = 10;
    }
}
