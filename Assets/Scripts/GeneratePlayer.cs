using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlayer : MonoBehaviour
{

    float playerSize = 1;
    float speed = 15;

    private GameObject playerObj;
    private GameObject playerObj2;


    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject player2Prefab;
    public static int numPlayers = 1;

    void Start()
    {
        // Generate the players on the screen
        this.playerObj = Instantiate(playerPrefab, new Vector3(-8, 0, 0), Quaternion.identity);
        this.playerObj.name = "Player";
        this.playerObj.transform.SetParent(this.gameObject.transform);


        if (numPlayers == 2)
        {
            playerObj2 = Instantiate(player2Prefab, new Vector3(-8, 3, 0), Quaternion.identity);
            this.playerObj2.name = "Player2";
            this.playerObj2.transform.SetParent(this.gameObject.transform);

        }
    }

}
