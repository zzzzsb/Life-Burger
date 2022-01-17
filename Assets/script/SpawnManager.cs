using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    public CustomerManager[] cList;
    float currentTime;
    public float createTime = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            currentTime = 0;
            int rValue = Random.Range(0, cList.Length);
            cList[rValue].CreateCustomer();
        }


    }
}
