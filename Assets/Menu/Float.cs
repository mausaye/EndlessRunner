using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    // Bounds for floating animation
    private float top;
    private float bottom;
    private float offset;
    private bool up;

    void Start()
    {
        // Initialize how much float distance
        this.up = false;
        this.offset = 0.3f;
        this.top = this.gameObject.transform.position.y + offset;
        this.bottom = this.gameObject.transform.position.y - offset;

    }

    void Update()
    {
        if (up)
        {
            this.gameObject.transform.Translate(0, Time.deltaTime/2, 0);
        } else
        {
            this.gameObject.transform.Translate(0, -Time.deltaTime/2, 0);
        }

        if (this.gameObject.transform.position.y >= top) up = false;
        else if (this.gameObject.transform.position.y <= bottom) up = true;

    }
}
