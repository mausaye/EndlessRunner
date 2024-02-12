using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlayer : MonoBehaviour
{

    float playerSize = 1;
    float speed = 15;

    private GameObject playerObj;
    [SerializeField] private GameObject playerPrefab;

    static int SIZE = 50;

    // Start is called before the first frame update
    void Start()
    {
        this.playerObj = Instantiate(playerPrefab, new Vector3(-9, 0, 0), Quaternion.identity);
        this.playerObj.transform.SetParent(this.gameObject.transform);
    }

}
