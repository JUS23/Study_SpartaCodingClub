using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rtan : MonoBehaviour
{
    float direction = 0.01f;
    float toward = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            toward *= -1f;
            direction *= -1f;
        }
        /*
        if (Input.GetMouseButtonDown(0))
        Debug.Log("Pressed left click.");

        if (Input.GetMouseButtonDown(1))
        Debug.Log("Pressed right click.");

        if (Input.GetMouseButtonDown(2))
        Debug.Log("Pressed middle click.");
        */

        if (transform.position.x > 2.8f)
        {
            direction *= -1f;
            toward = -1.0f;
        }

        if (transform.position.x < -2.8f)
        {
            direction *= -1f;
            toward = 1.0f;
        }

        transform.localScale = new Vector3(toward, 1f, 1f);
        transform.position += new Vector3(direction, 0, 0);

        //Debug.Log(transform.position.x);
    }
}
