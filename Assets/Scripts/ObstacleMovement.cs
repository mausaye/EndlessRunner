using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    float velocity;
    float acc;
    float increaseSpeed;

    // Start is called before the first frame update
    void Start()
    {
         velocity = 0f;
         acc = 0.01f;
         increaseSpeed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(-velocity*acc*Time.deltaTime, 0, 0);
        velocity += acc;
        acc += (increaseSpeed * (UIManager.round/1.5f) * Time.deltaTime);
        

        if(this.transform.position.x < -15 || this.transform.position.x > 15 || this.transform.position.y < -15 || this.transform.position.y > 15)
        {
            Destroy(this.gameObject);
        }
    }

 
}
