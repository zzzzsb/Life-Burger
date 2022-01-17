using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// 각 햄버거 파츠별 공장을 만들고
// 각 파츠별 생성 함수를 만든다.
public class HamburgerManager : MonoBehaviour
{


    //각 재료별 공장
    public GameObject topFactory;
    public GameObject meatFactory;
    public GameObject bottomFactory;
    public GameObject tomatoFactory;
    public GameObject cheeseFactory;
    public GameObject lettuceFactory;
    public GameObject friesFactory;
    public GameObject icecreamFactory;

    List<GameObject> createdParts = new List<GameObject>();
    public List<string> comparedList = new List<string>();

    private RecipeManager recipeScript;

    // 맞았을때 체크표시 
    public GameObject greenbottomcheck;
    public GameObject greenmaterial1check;
    public GameObject greenmaterial2check;
    public GameObject greenmaterial3check;
    public GameObject greenmaterial4check;
    public GameObject greentopcheck;

    // 틀렸을때 엑스표시
    public GameObject redbottomcheck;
    public GameObject redmaterial1check;
    public GameObject redmaterial2check;
    public GameObject redmaterial3check;
    public GameObject redmaterial4check;
    public GameObject redtopcheck;

    public GameObject tray;
    public GameObject trayPosition;

    // Start is called before the first frame update
    void Start()
    {
        
        greenbottomcheck.SetActive(false);
        greenmaterial1check.SetActive(false);
        greenmaterial2check.SetActive(false);
        greenmaterial3check.SetActive(false);
        greenmaterial4check.SetActive(false);
        greentopcheck.SetActive(false);

        redbottomcheck.SetActive(false);
        redmaterial1check.SetActive(false);
        redmaterial2check.SetActive(false);
        redmaterial3check.SetActive(false);
        redmaterial4check.SetActive(false);
        redtopcheck.SetActive(false);

        // 트레이 생성
        GameObject trayGameobject = Instantiate(tray);
        
    }

    // Update is called once per frame
    void Update()
    {
        // 트레이 움직이게
        //Vector3 velo = Vector3.zero;
        tray.transform.position = Vector3.Lerp(tray.transform.position, trayPosition.transform.position, 0.1f);

    }

    public void OnClickMakeTop()
    {
        MakePart(topFactory);
        comparedList.Add("top");
        Check();
        //print("top");
    }

    public void OnClickMakeMeat()
    {
        MakePart(meatFactory);
        comparedList.Add("meat");
        Check();
        //print("meat");
    }

    public void OnClickMakeBottom()
    {
        MakePart(bottomFactory);
        comparedList.Add("bottom");
        Check();
        //print("bottom");
    }

    public void OnClickMakeTomato()
    {
        MakePart(tomatoFactory);
        comparedList.Add("tomato");
        Check();
        //print("tomato");
    }

    public void OnClickMakeCheese()
    {
        MakePart(cheeseFactory);
        comparedList.Add("cheese");
        Check();
        //print("cheese");
    }

    public void OnClickMakeLettuce()
    {
        MakePart(lettuceFactory);
        comparedList.Add("lettuce");
        Check();
        //print("lettuce");
    }

    public void OnClickMakeFries()
    {
        MakePart(friesFactory);
        comparedList.Add("fries");
        Check();
        //print("fries");
    }

    public void OnClickMakeIceCream()
    {
        MakePart(icecreamFactory);
        comparedList.Add("icecream");
        Check();
        //print("icecream");
    }



    public void MakePart(GameObject factory)
    {
        GameObject part = Instantiate(factory);
        createdParts.Add(part.gameObject);
        // 나의 부모 = 너
        part.transform.parent = transform;
        part.transform.position = transform.position;

    }

    private void Check()
    {
        int i = 0;
        recipeScript = GameObject.Find("RecipeManager").GetComponent<RecipeManager>();

        // 레시피순서와 버튼 눌러서 생성된 게임오브젝트 이름이 같으면 체크표시를 활성화 한다.
        if (comparedList.Count == 1)
        {
            i = 0;
        }
        if(comparedList.Count == 2)
        {
            i = 1;
        }
        if(comparedList.Count == 3)
        {
            i = 2;
        }
        if(comparedList.Count == 4)
        {
            i = 3;
        }
        if(comparedList.Count == 5)
        {
            i = 4;
        }
        if(comparedList.Count == 6)
        {
            i = 5;
        }

        if(recipeScript.MaterialList[i] == comparedList[i])
        {
            if (i == 0)
            {
                greenbottomcheck.SetActive(true);
            }
            else if(i == 1)
            {
                greenmaterial1check.SetActive(true);
            }
            else if(i == 2)
            {
                greenmaterial2check.SetActive(true);
            }
            else if(i == 3)
            {
                greenmaterial3check.SetActive(true);
            }
            else if(i == 4)
            {
                greenmaterial4check.SetActive(true);
            }
            else if(i == 5)
            {
                greentopcheck.SetActive(true);
            }
            
        }
        

        else
        {
            // 레시피순서와 버튼 눌러서 생성된 게임오브젝트 이름이 다르면 해당 레시피 이미지를 빨갛게 바꾸고싶다.
            if (i == 0)
            {
                redbottomcheck.SetActive(true);
            }
            else if (i == 1)
            {
                redmaterial1check.SetActive(true);
            }
            else if (i == 2)
            {
                redmaterial2check.SetActive(true);
            }
            else if (i == 3)
            {
                redmaterial3check.SetActive(true);
            }
            else if (i == 4)
            {
                redmaterial4check.SetActive(true);
            }
            else if (i == 5)
            {
                redtopcheck.SetActive(true);
            }

        }
    }
    public void OnClickHamburgerComplete()
    {
        tray.transform.position = Vector3.Lerp(tray.transform.position, trayPosition.transform.position, 0.1f);

        comparedList.Clear();


        // 각 햄버거 파츠를 파괴한다.
        for (int i = 0; i < createdParts.Count; i++)
        {
            Destroy(createdParts[i].gameObject);
        }

        createdParts.Clear();

    }

}
