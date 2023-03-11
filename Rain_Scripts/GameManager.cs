using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject rain;
    public GameObject panel;
    public static GameManager I;        //싱글톤 화
    public Text scoreText;
    public Text timeText;
    int totalScore;
    float limit;

    void Awake()
    {
        I = this;		                //싱글톤 화
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeRain", 0, 0.5f);
        initGame();
    }

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;
        if (limit < 0)
        {
            Time.timeScale = 0.0f;      //유니티Scene를 정지시킴
            panel.SetActive(true);
            limit = 0.0f;
        }
        timeText.text = limit.ToString("N2");       //소수둘째자리까지
    }

    void makeRain()
    {
        Instantiate(rain);
    }

    public void addScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");        //scene 새로불러오기
    }

    void initGame()
    {
        Time.timeScale = 1.0f;      //실제시간으로 흐른다 0.5f 흐르는 속도가 절반
        totalScore = 0;             //빗방울
        limit = 60f;                //남은시간
    }
}
