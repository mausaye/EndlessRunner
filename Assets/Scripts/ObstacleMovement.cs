using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    // obstacle speed
    float velocity;

    void Start()
    {
         velocity = Random.Range(2,4);
    }

    void Update()
    {
        // Moves obstacles at a constant rate for first 10 rounds then as rounds increase, speed marginally increases
        this.gameObject.transform.Translate(-velocity * (UIManager.round <= 10? 1: UIManager.round/10) *Time.deltaTime, 0, 0);

        if(Helpers.outOfBound(this.gameObject))
        {
            Destroy(this.gameObject);
        }
    }

 
}
