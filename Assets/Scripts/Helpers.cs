using System;
using UnityEngine;

public class Helpers
{
    // Keeps track of out of bounds
    public static bool outOfBound(GameObject obj)
    {
        return (obj.transform.position.y < -7 || obj.transform.position.y > 7 || obj.transform.position.x > 60 || obj.transform.position.x < -20);

    }
}

