using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RecipeArray;
using System;
using System.Linq;

//햄버거 잘못만들면 그 뒤로 점수 카운트가 안되는 에러 고쳐야함.
//점수 카운트 하고 레시피비교리스트 생성할수 있게 Invoke("MakeMaterialList", 2f); 추가.

public class RecipeManager : MonoBehaviour
{
    public GameObject[] recipes = new GameObject[6];
    public GameObject[] resave = new GameObject[6];

    public GameObject[] sides = new GameObject[2];
    public GameObject[] sideresave = new GameObject[2];

    GameObject[] CloneMaterial = new GameObject[6];
    GameObject material;
    GameObject sidematerial;


    // (비교할 리스트)배열의 햄버거 재료 순서를 넣을 리스트 생성
    public List<string> MaterialList = new List<string>();
    public List<string> sideMaterialList = new List<string>();


    // 재료 게임 오브젝트 배열에서 null을 없앤 게임오브젝트 리스트 생성
    public List<GameObject> GameObjectMaterialList = new List<GameObject>();
    public List<GameObject> sideGameObjectMaterialList = new List<GameObject>();
    

    public GameObject bottomLocation;
    public GameObject Material1Location;
    public GameObject Material2Location;
    public GameObject Material3Location;
    public GameObject Material4Location;
    public GameObject topLocation;
    public GameObject pototoLocation;
    public GameObject icecreamLocation;

    // Start is called before the first frame update
    void Start()
    {
        // 랜덤레시피 생성
        MakeRecipe();
        // 햄버거 순서와 비교할 레시피 문자열 리스트 생성
        MakeMaterialList();
        // 렌덤레시피 배치
        PlaceRecipe();
       
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickRecipeComplete()
    {
        // Invoke("MakeMaterialList", 2f);
        // 이전 레시피의 오브젝트들을 제거한다.
        // MaterialList.Clear();
        for (int i = 0; i < GameObjectMaterialList.Count; i++)
        {
            Destroy(GameObjectMaterialList[i].gameObject);
        }
        for (int i=0; i< sideGameObjectMaterialList.Count; i++)
        {
            Destroy(sideGameObjectMaterialList[i].gameObject);
        }

        GameObjectMaterialList.Clear();
        sideGameObjectMaterialList.Clear();


        // 랜덤 레시피 생성하기
        MakeRecipe();
        // 레시피 출력
        PlaceRecipe();
        MakeMaterialList();

    }

    // 랜덤으로 재료를 배치하여 레시피를 생성한다.
    private void MakeRecipe()
    {
        // 배열 내의 항목을 섞어서 30퍼센트의 확률로 null값을 넣는다.
        RecipeArray.Array.shuffle(recipes, resave);
        for (int i = 1; i < 5; i++)
        {
            if (UnityEngine.Random.Range(1, 100) < 30)
            {
                recipes[i] = null;
            }
        }

        RecipeArray.Array.sideshuffle(sides, sideresave);
        for (int i = 0; i < 2; i++)
        {
            if (UnityEngine.Random.Range(1, 100) < 70)
            {
                sides[i] = null;
            }
        }

        // null값 없는 게임오브젝트 재료 리스트 생성
        for (int i = 0; i < 6; i++)
        {
            // 해당 인덱스에 재료가 있다면
            if (recipes[i] != null)
            {
                // 해당 인덱스의 재료를 생성하여
                GameObject material = Instantiate(recipes[i]);
                // 클론재료 배열에 넣는다. (나중에 재료게임오브젝트를 한꺼번에 삭제하기 위함)
                GameObjectMaterialList.Add(material);
            }
            // 해당 인덱스에 재료가 없다면
            else
            {
                continue;
            }

        }

        // null값 없는 게임오브젝트 재료 리스트 생성
        for (int i = 0; i < 2; i++)
        {
            // 해당 인덱스에 재료가 있다면
            if (sides[i] != null)
            {
                // 해당 인덱스의 재료를 생성하여
                GameObject sidematerial = Instantiate(sides[i]);
                // 클론재료 배열에 넣는다. (나중에 재료게임오브젝트를 한꺼번에 삭제하기 위함)
                sideGameObjectMaterialList.Add(sidematerial);
            }
            // 해당 인덱스에 재료가 없다면
            else
            {
                continue;
            }

        }


        // 순서 비교할 레시피 리스트 생성
        //Invoke("MakeMaterialList", 1f);
    }
    

    // 랜덤으로 만들어진 레시피 순서에 따라 재료가 우측 상단에 나타나게 하고싶다.
    // 공백 없이 레시피 출력
    private void PlaceRecipe()
    {
        for (int i = 0; i < GameObjectMaterialList.Count; i++)
        {
            // 레시피 배경 앞에 나타나게 하고싶다.
            if (i == 0)
            {
                GameObjectMaterialList[i].gameObject.transform.position = bottomLocation.transform.position;
            }
            else if (i == 1)
            {
                GameObjectMaterialList[i].gameObject.transform.position = Material1Location.transform.position;
            }
            else if (i == 2)
            {
                GameObjectMaterialList[i].gameObject.transform.position = Material2Location.transform.position;
            }
            else if (i == 3)
            {
                GameObjectMaterialList[i].gameObject.transform.position = Material3Location.transform.position;
            }
            else if (i == 4)
            {
                GameObjectMaterialList[i].gameObject.transform.position = Material4Location.transform.position;
            }
            else if (i == 5)
            {
                GameObjectMaterialList[i].gameObject.transform.position = topLocation.transform.position;
            }
            
        }

        for ( int i = 0; i < sideGameObjectMaterialList.Count; i++)
        {
            if (sideGameObjectMaterialList[i].name.Contains("potato"))
            {
                sideGameObjectMaterialList[i].gameObject.transform.position = pototoLocation.transform.position;
            }
            else if (sideGameObjectMaterialList[i].name.Contains("icecream"))
            {
                sideGameObjectMaterialList[i].gameObject.transform.position = icecreamLocation.transform.position;
            }
        }
        
    }

    // 순서 비교할 재료 리스트(string) 생성 
    public void MakeMaterialList()
    {
        sideMaterialList.Clear();
        MaterialList.Clear();
        for (int i = 0; i < GameObjectMaterialList.Count; i++)
        {
            if (GameObjectMaterialList[i].name.Contains("bottom 1"))
            {
                MaterialList.Add("bottom");
            }
            else if (GameObjectMaterialList[i].name.Contains("top 1"))
            {
                MaterialList.Add("top");
            }
            else if (GameObjectMaterialList[i].name.Contains("cheese 1"))
            {
                MaterialList.Add("cheese");
            }
            else if (GameObjectMaterialList[i].name.Contains("lettuce 1"))
            {
                MaterialList.Add("lettuce");
            }
            else if (GameObjectMaterialList[i].name.Contains("meat 1"))
            {
                MaterialList.Add("meat");
            }
            else if (GameObjectMaterialList[i].name.Contains("tomato 1"))
            {
                MaterialList.Add("tomato");
            }
            
        }
        for(int i =0; i< sideGameObjectMaterialList.Count; i++)
        {
            if (sideGameObjectMaterialList[i].name.Contains("potato 1"))
            {
                sideMaterialList.Add("fries");
            }
            else if (sideGameObjectMaterialList[i].name.Contains("icecream 1"))
            {
                sideMaterialList.Add("icecream");
            }
        }
    }

}
