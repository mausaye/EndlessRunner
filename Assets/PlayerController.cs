using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    float playerSize = 1;
    float speed = 15;

    static int SIZE = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() { 

        if (Input.GetKey(KeyCode.W)) {
            this.gameObject.transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S)){
            // this.y = this.y - 1;
            this.gameObject.transform.Translate(0, -speed * Time.deltaTime, 0);
        }

       // playerObj.transform.position = new Vector3(-9, y, 0);
     
    }

    private void OnCollisionEnter(Collision collision)
    {
       
       UIManager.isGameOver = true ;
    }

 
}
