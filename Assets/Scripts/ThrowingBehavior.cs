using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBehavior : MonoBehaviour
{
    // Throwing mob prefabs
    public GameObject acornPrefab;
    private GameObject player;
    public GameObject throwingMob;
    private GameObject acorn;

    private bool isThrowing;

    private Vector3 lastKnownPlayerPosition;
    private Animator animator;

    void Start()
    {
        this.isThrowing = false;
        player = GameObject.Find("Player"); 
        lastKnownPlayerPosition = new Vector3(0, 0, 0);
        this.animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // Makes sure squirrel faces player
        if(this.gameObject.transform.position.x < player.transform.position.x)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        // If not currently throwing an acorn, throw an acorn
        if (!isThrowing)
        {
            isThrowing = true;
            acorn = Instantiate(acornPrefab, new Vector3(throwingMob.transform.position.x, throwingMob.transform.position.y, 0), Quaternion.identity);
            acorn.layer = LayerMask.NameToLayer("UI");
            acorn.transform.parent = throwingMob.transform;
            lastKnownPlayerPosition = player.transform.position;
            this.animator.SetBool("isThrowing", true);

        } else // Update acorn position
        {
            updateAcornPosition();
            this.animator.SetBool("isThrowing", false);

        }

        transform.Translate(-Time.deltaTime * 3, 0, 0);

        // Destroy on out of bounds
        if (Helpers.outOfBound(this.gameObject))
        {
            Destroy(this.gameObject);
        }
    }

    void updateAcornPosition()
    {
        // Create normal vector of direction towards player
        Vector3 direction = (lastKnownPlayerPosition - transform.position).normalized;

        // Move this object in the calculated direction
        acorn.transform.Translate(direction * 5 * Time.deltaTime);

        if (Helpers.outOfBound(acorn))
        {
            Destroy(acorn);
            isThrowing = false;
        }

    }
}
