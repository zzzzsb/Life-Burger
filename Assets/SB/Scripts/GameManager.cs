using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public GameObject gameOverUI;
    //public GameObject gameStartUI;

    // Start is called before the first frame update
    void Start()
    {
        // 게임이 시작되면 시간을 흐르게 한다.
        Time.timeScale = 1;
        // 태어날 때 게임시작 창을 보이게 한다.
        //gameStartUI.SetActive(true);

        // 태어날 때 게임오버 창을 보이지 않게 한다.
        //gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ClickOnStart()
    {
        // gameStartUI.SetActive(false);

        SceneManager.LoadScene("hamburger_Scaled");
        //Time.timeScale = 1;
    }

    public void ClickOnRestart()
    {
        SceneManager.LoadScene("hamburger_Scaled");
    }
}
