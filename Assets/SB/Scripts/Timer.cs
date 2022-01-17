using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime;
    public Text text_Timer;
    public GameObject gameOverUI;
    public GameObject gameStartUI;

    public GameObject lastTrayPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LimitTime -= Time.deltaTime;
        text_Timer.text = "" + Mathf.Round(LimitTime);

        if (LimitTime <= 0f)
        {
            Time.timeScale = 0;
            GameObject lastTray = GameObject.Find("Tray");
            lastTray.transform.position = Vector3.Lerp(lastTray.transform.position, lastTrayPosition.transform.position, 0.1f);

            //Invoke("GameOver", 5f);
            gameOverUI.SetActive(true);

        }
    }

    private void GameOver()
    {
        // 시간을 멈추고
        //Time.timeScale = 0;
        // 게임오버 창을 띄운다.
        //gameOverUI.SetActive(true);
    }
}
