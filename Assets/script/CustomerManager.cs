using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerManager : MonoBehaviour
{
    // Start is called before the first frame update

    //public float minCreateTime = 1;
   // public float maxCreateTime = 3;

    float createTime = 1;
    float currentTime;

    public GameObject[] customerFactory;
    public Transform orderPosition;
    GameObject post_customer;

    void Start()
    {
        //createTime = Random.Range(minCreateTime, maxCreateTime);
        CreateCustomer();
    }

    // Update is called once per frame
    void Update()
    {

        

    }
    public void CreateCustomer()
    {
        if (GameManager.Instance.gameOverUI.activeSelf == false)
        {
            int rValue = Random.Range(0, customerFactory.Length);
            // 3 customer공장에서 customer를 만들어서
            GameObject customer = Instantiate(customerFactory[rValue]);
            post_customer = customer;
            // 4 내 위치에 가져다 놓고싶다.
            customer.transform.position = orderPosition.transform.position;
        }
    }

    public void OnClickComplete()
    {
        Destroy(post_customer);
        Invoke("CreateCustomer",0.3f);
    }
}
