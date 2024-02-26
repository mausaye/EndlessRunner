using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PoofBehavior : MonoBehaviour
{
    public GameObject puffPrefab;
    public GameObject puffMob;
    private bool isPuffing;
    private GameObject[] puffs;
    private int numPuffs;
    private int counter;

    void Start()
    {
        this.isPuffing = false;
        numPuffs = 3;
        counter = 0;
        puffs = new GameObject[numPuffs];
    }

    void Update()
    {
        if (!isPuffing)
        {
            for(int i = 0; i < numPuffs; i++)
            {
                puffs[i] = Instantiate(puffPrefab, new Vector3(puffMob.transform.position.x, puffMob.transform.position.y, 0), Quaternion.identity);
                puffs[i].transform.parent = puffMob.transform;
            }
            isPuffing = true;
        }
        else { updatePuffPosition(); }

        if (Helpers.outOfBound(this.gameObject))
        {
            Destroy(this.gameObject);
        }

    }

    void deleteOutOfBounds(GameObject puff)
    {
        if (puff && Helpers.outOfBound(puff))
        {

            for (int i = 0; i < 3; i++)
            {
                Destroy(puffs[i]);
            }
            
            isPuffing = false;
            
            
        }
    }

    void updatePuffPosition()
    {
        puffs[0].transform.Translate(new Vector3(-Time.deltaTime, -0.1f * Time.deltaTime, 0) * 5);
        puffs[1].transform.Translate(new Vector3(-Time.deltaTime, 0.0f * Time.deltaTime, 0) * 5);
        puffs[2].transform.Translate(new Vector3(-Time.deltaTime, 0.1f * Time.deltaTime, 0) * 5);

        deleteOutOfBounds(puffs[0]);
        deleteOutOfBounds(puffs[1]);
        deleteOutOfBounds(puffs[2]);
    }
}
