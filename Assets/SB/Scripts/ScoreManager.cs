using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public Text scoreText;
    public Text expText;
    private RecipeManager recipeScript;
    private HamburgerManager hamburgerScript;
    private int score;
    public int exp = 0;
    // int compareCount = 0;

    public GameObject heartFactory;
    public GameObject skullFactory;
    public Transform expressionPosition;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score + "";
        expText.text = "exp " + exp + "/" + "100";
        //recipeScript = GameObject.Find("RecipeManager").GetComponent<RecipeManager>();
        //recipeScript.MakeMaterialList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickComplete()
    {
        recipeScript = GameObject.Find("RecipeManager").GetComponent<RecipeManager>();
        hamburgerScript = GameObject.Find("hamburger").GetComponent<HamburgerManager>();
        
        for (int i =0; i< recipeScript.sideMaterialList.Count; i++)
        {
            recipeScript.MaterialList.Add(recipeScript.sideMaterialList[i]);
        }

        for (int i = 0; i< hamburgerScript.comparedList.Count; i++)
        {
            // 리스트 항목이 같으면 계속 비교
            if (hamburgerScript.comparedList[i]==recipeScript.MaterialList[i] )
            {
                if (i == (hamburgerScript.comparedList.Count - 1))
                {
                    GameObject heart = Instantiate(heartFactory);
                    heart.transform.position = expressionPosition.position;
                    // 마지막 재료까지 비교했는데 같다면 점수를 5점 준다.
                    score += 5;
                    exp += 5;
                    // 레시피와 일치하는 햄버거가 완성되면 손님 주위로 긍정적 이펙트
                    
                }
                continue;
            }
            // 리스트 항목이 다르면 
            else
            {
                GameObject skull = Instantiate(skullFactory);
                skull.transform.position = expressionPosition.position;
                hamburgerScript.comparedList.Clear();
                recipeScript.MaterialList.Clear();
                exp -= 3;
                // 레시피와 일치하지 않는 햄버거가 완성되면 손님 주위로 부정적 이펙트
                
                break;
            }
        }
        scoreText.text = score + "";
        expText.text = "exp " + exp + "/" + "100";

        hamburgerScript.OnClickHamburgerComplete();
        recipeScript.OnClickRecipeComplete();

        hamburgerScript.greenbottomcheck.SetActive(false);
        hamburgerScript.greenmaterial1check.SetActive(false);
        hamburgerScript.greenmaterial2check.SetActive(false);
        hamburgerScript.greenmaterial3check.SetActive(false);
        hamburgerScript.greenmaterial4check.SetActive(false);
        hamburgerScript.greentopcheck.SetActive(false);

        hamburgerScript.redbottomcheck.SetActive(false);
        hamburgerScript.redmaterial1check.SetActive(false);
        hamburgerScript.redmaterial2check.SetActive(false);
        hamburgerScript.redmaterial3check.SetActive(false);
        hamburgerScript.redmaterial4check.SetActive(false);
        hamburgerScript.redtopcheck.SetActive(false);
    }

}
