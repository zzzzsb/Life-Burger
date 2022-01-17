using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickComplete()
    {
        if (gameObject.transform.parent != null)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);

        }
    }

  //  [SerializeField]
  //  GameObject objectToDestroy;

  //  public void DestroyGameObject()
  //  {
  //      Destroy(objectToDestroy);
  //  }

}


