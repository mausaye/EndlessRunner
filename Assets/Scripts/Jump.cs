using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    float velocity = 5.0f;
    float acc;
    float accInit = -100;
    float gravity = 30f;
    float yPos;
    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        acc = accInit;
        yPos = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
    
        velocity -= acc * Time.deltaTime;
        yPos += velocity;
        yPos *= Time.deltaTime;
        
        this.transform.Translate(-6 * Time.deltaTime, yPos, 0);

        if(yPos < -1)
          Destroy(this.gameObject);

        if (counter > 0.15) acc = gravity;
        counter += Time.deltaTime;
       // Debug.Log(counter);
        //Debug.Log(this.gameObject.transform.position.x +" " +this.gameObject.transform.position.y);

    }

}
