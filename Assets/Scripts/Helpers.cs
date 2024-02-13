using System;
using UnityEngine;

public class Helpers
{
    public static bool outOfBound(GameObject obj)
    {
        return (obj.transform.position.y < -7 || obj.transform.position.y > 7 || obj.transform.position.x > 10 || obj.transform.position.x < -10);

    }
}

