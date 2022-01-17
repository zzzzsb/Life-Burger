using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject gameOverUI;
    //게임을 다시 시작한다 

    public void onClickRestart()
    {
        gameOverUI.SetActive(false);
        SceneManager.LoadScene("StartTitle");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
