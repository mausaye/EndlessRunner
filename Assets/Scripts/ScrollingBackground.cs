using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed;
    [SerializeField] Renderer render;

    // Offset the material such that the background moves
    void Update() 
    {
        render.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
