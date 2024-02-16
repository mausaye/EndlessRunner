using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMovement : MonoBehaviour
{
    float curveSpeed;
    float speed;
    float radius;
    float fTime;
    private Vector3 lastPos;
    private Vector3 line;
    // Start is called before the first frame update
    void Start()
    {
        curveSpeed = 5;
        speed = 0.5f;
        radius = 2f;
        fTime = 0;
        lastPos = Vector3.zero;
        line = new Vector3(-speed * 5, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        lastPos = transform.position;
        fTime += Time.deltaTime * curveSpeed;

        Vector3 sine = new Vector3(0, Mathf.Sin(fTime) * radius, 0);
        transform.position += (sine + line) * Time.deltaTime;


    }
}
