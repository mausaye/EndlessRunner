using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager Instance;
    public bool starGenerated;
    public void Awake()
    {
        if (!Instance) Instance = this;
    }


    public int round = 0;

    void Start()
    {
        starGenerated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
