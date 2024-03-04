using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Jump mob simple physics
    private float velocity = 5.0f;
    private float acc;
    private float accInit = -100;
    private float gravity = 30f;
    private float yPos;
    private float counter = 0;
    private Animator anim;

    void Start()
    {
        // Initialize animator and position of mob
        this.anim = this.gameObject.GetComponent<Animator>();
        acc = accInit;
        yPos = this.gameObject.transform.position.y;
    }

    void Update()
    {

        // Updates the velocity to mimic real life (kinda)
        velocity -= acc * Time.deltaTime;
        yPos += velocity;
        yPos *= Time.deltaTime;
        
        this.transform.Translate(-6 * Time.deltaTime, yPos, 0);

        // Destroy if out of bounds
        if (Helpers.outOfBound(this.gameObject))
          Destroy(this.gameObject);

        // Gives some time before object falls
        if (counter > 0.15) acc = gravity;
        counter += Time.deltaTime;

        // Set animation for falling
        if (isFalling()) anim.SetBool("JumpDown", true);
      
    }

    public bool isFalling()
    {
        return velocity <= 0;
    }

}
