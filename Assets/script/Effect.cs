using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    //폭발effect공장
    public GameObject expFactory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {

        //폭발 이펙트 공장에서 폭발 이펙트를 가져와서 내 위치에 가져가 놓고싶다
        GameObject exp = Instantiate(expFactory);

        exp.transform.position = transform.position;
    }
}
