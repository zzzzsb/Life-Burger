using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//햄버거 재료끼리 부딪혔을 때 poof이펙트를 주고싶다
//폭발이펙트 공장
public class hamburgerMove : MonoBehaviour
{
    
    

    public GameObject target;
    public float speed = 8;

    public Vector3 startPosition;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Plate");
        //print(target.name);
        dir = Vector3.back;
        //dir = target.transform.position - transform.position;
        //dir.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {

       
        // print(other.gameObject.name);
        if (other.gameObject == target)
        {
            speed = 0;
        }
    }

    public void OnClickComplete()
    {

    }
}
