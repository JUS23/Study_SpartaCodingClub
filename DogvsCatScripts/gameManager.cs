using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject dog;
    public GameObject food;
    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;
    public GameObject retryBtn;
    public Text levelText;
    public GameObject levelFront;

    public static gameManager I;

    int level = 0;
    int cat = 0;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("makeFood", 0.0f, 0.1f);
        InvokeRepeating("makeCat", 0.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void makeFood()
    {
        float x = dog.transform.position.x;
        float y = dog.transform.position.y + 2.0f;
        Instantiate(food, new Vector3(x, y, 0), Quaternion.identity);       //3차원 좌표를 넣어야하기 때문에 회전값을 넣어준다 별 뜻없다.		
    }

    void makeCat()
    {
        Instantiate(normalCat);
        if (level == 1)
        {
            float p = Random.Range(0, 10);
            if (p < 3) Instantiate(normalCat);
        }
        if (level == 2)
        {
            float p = Random.Range(0, 10);
            if (p < 4) Instantiate(normalCat);
        }
        if (level >= 3)
        {
            float p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
            Instantiate(fatCat);
        }
        if (level >= 4)
        {
            float p = Random.Range(0, 10);
            Instantiate(pirateCat);
        }
    }

    public void gameOver()
    {
        {
            retryBtn.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void addCat()
    {
        cat += 1;
        level = cat / 5;                //cat은 정수라 0이다

        levelText.text = level.ToString();
        levelFront.transform.localScale = new Vector3((cat - level * 5) / 5.0f, 1.0f, 1.0f);        //좀 이해가 안됨
    }
}
