using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject square;
    public GameObject endPanel;
    public Text timeTxt;
    public Text thisScoreTxt;
    public Text maxScoreTxt;
    public Animator anim;

    bool isRunning = true;

    float alive = 0f;
    float maxScore;
    public static gameManager I;

    void Awake()
    {
        I = this;       //자기자신을 호출 (싱글톤)
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;        //게임시작
        InvokeRepeating("makeSquare", 0.0f, 0.5f);
        endPanel.SetActive(false);
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            alive += Time.deltaTime;
            timeTxt.text = alive.ToString("N2");        //ToString = 숫자를 문자열로 바꾸기
        }
    }

    void makeSquare()
    {
        Instantiate(square);
    }

    public void gameOver()
    {
        isRunning = false;              //좀 더 정확한 정지 및 score 계산을 위함
        anim.SetBool("isDie", true);
        Invoke("timeStop", 0.5f);
        endPanel.SetActive(true);
        thisScoreTxt.text = alive.ToString("N2");

        if (PlayerPrefs.HasKey("bestscore") == false)       //영구 score 기억코드
        {
            PlayerPrefs.SetFloat("bestscore", alive);       //bestscore에 alive(지금기록)을 입력
        }
        else
        {
            if (alive > PlayerPrefs.GetFloat("bestscore"))
            {
                PlayerPrefs.SetFloat("bestscore", alive);
            }
        }
        float maxScore = PlayerPrefs.GetFloat("bestscore");
        maxScoreTxt.text = maxScore.ToString("N2");             //문자열로 변경하여 이전
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");        //UI를 클릭하여 재실행
    }

    void timeStop()
    {
        Time.timeScale = 0f;
    }
}
