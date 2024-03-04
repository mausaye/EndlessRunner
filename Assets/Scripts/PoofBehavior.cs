using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PoofBehavior : MonoBehaviour
{
    // Puff gameobject prefabs
    public GameObject puffPrefab;
    public GameObject puffMob;

    // Whether currently spawning puffs
    private bool isPuffing;

    // Stores the puffs generated
    private GameObject[] puffs;
    private int numPuffs;

    void Start()
    {
        // Initialize puff mob
        this.isPuffing = false;
        numPuffs = 3;
        puffs = new GameObject[numPuffs];
    }

    void Update()
    {
        // If no puffs, generate three puffs 
        if (!isPuffing)
        {
            for(int i = 0; i < numPuffs; i++)
            {
                puffs[i] = Instantiate(puffPrefab, new Vector3(puffMob.transform.position.x, puffMob.transform.position.y, 0), Quaternion.identity);
                puffs[i].transform.parent = puffMob.transform;
            }
            isPuffing = true;
        }
        else {
            // Update puff position if exist
            updatePuffPosition();
        }

        // Destory on out of bounds
        if (Helpers.outOfBound(this.gameObject))
        {
            Destroy(this.gameObject);
        }

    }

    // Destroy all puffs on single puff out of bounds
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
