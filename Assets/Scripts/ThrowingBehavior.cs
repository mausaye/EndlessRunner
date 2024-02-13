using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBehavior : MonoBehaviour
{
    public GameObject acornPrefab;
    private GameObject player;
    public GameObject throwingMob;
    private bool isThrowing;
    GameObject acorn;
    private Vector3 lastKnownPlayerPosition;

    // Start is called before the first frame update
     

    void Start()
    {
        this.isThrowing = false;
        player = GameObject.Find("Player"); // TODO: find better way to do this
        lastKnownPlayerPosition = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (!isThrowing)
        {
            acorn = Instantiate(acornPrefab, new Vector3(throwingMob.transform.position.x, throwingMob.transform.position.y, 0), Quaternion.identity);
            acorn.transform.parent = throwingMob.transform;
            lastKnownPlayerPosition = player.transform.position;
            isThrowing = true;

        } else
        {
            updateAcornPosition();

        }

        transform.Translate(-Time.deltaTime, 0, 0);

        if (Helpers.outOfBound(this.gameObject)) Destroy(this.gameObject);
        
    }

    void updateAcornPosition()
    {
        Vector3 direction = (lastKnownPlayerPosition - transform.position).normalized;

        // Move this object in the calculated direction
        acorn.transform.Translate(direction * 10 * Time.deltaTime);

        if (Helpers.outOfBound(acorn))
        {
            Destroy(acorn);
            isThrowing = false;
        }



    }
}
