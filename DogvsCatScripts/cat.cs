using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    float full = 5f;
    float energy = 0f;
    bool isFull = false;
    public int type;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30f;
        if (type == 1)
        {
            full = 7f;
        }
        if (type == 2)
        {
            full = 3f;
        }
        transform.position = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full)
        {
            if (type == 0)
            {
                transform.position += new Vector3(0, -0.01f, 0);
            }
            else if (type == 1)
            {
                transform.position += new Vector3(0, -0.005f, 0);
            }
            else if (type == 2)
            {
                transform.position += new Vector3(0, -0.015f, 0);
            }

            if (transform.position.y < -16f)
            {
                gameManager.I.gameOver();
            }
        }
        if (energy >= full)
        {
            if (transform.position.x > 0)
            {
                transform.position += new Vector3(0.01f, 0, 0);
            }
            else
            {
                transform.position += new Vector3(-0.01f, 0, 0);
            }
            Destroy(gameObject, 3f);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "food")
        {
            if (energy < full)
            {
                energy += 1f;
                Destroy(coll.gameObject);       //맞은 tag == "food" 를 Destroy
                gameObject.transform.Find("hungry/Canvas/front").transform.localScale = new Vector3(energy / full, 1.0f, 1.0f);
            }
            if (energy >= full)
            {
                if (isFull == false)
                {
                    gameManager.I.addCat();
                    gameObject.transform.Find("hungry").gameObject.SetActive(false);
                    gameObject.transform.Find("full").gameObject.SetActive(true);
                    isFull = true;
                }
            }
        }
    }
}
