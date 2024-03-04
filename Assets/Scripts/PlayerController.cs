using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    float playerSize = 1;
    float speed = 15;

    private Camera mainCamera;
    private Vector3 minBounds;
    private Vector3 maxBounds;
    private Vector3 objectSize;
    private bool rotate;

    private Animator animator;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        this.animator = this.gameObject.GetComponent<Animator>();
        CalculateBounds();
        gm = GameManager.Instance;
        rotate = false;
        
    }

    // Update is called once per frame
    void Update() {

        // Ensure player does not go outside of the camera bounds
        if (this.gameObject.transform.position.y < maxBounds.y) { this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, maxBounds.y, 0);  }
        else if (this.gameObject.transform.position.x < minBounds.x) { this.gameObject.transform.position = new Vector3(minBounds.x, this.gameObject.transform.position.y, 0); }
        else if (this.gameObject.transform.position.y > minBounds.y) { this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, minBounds.y, 0); }
        else if (this.gameObject.transform.position.x > maxBounds.x) { this.gameObject.transform.position = new Vector3(maxBounds.x, this.gameObject.transform.position.y, 0); }

        // Move player based on key press
        if (Input.GetKey(this.up)) {
            this.gameObject.transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(this.down)){
            this.gameObject.transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(this.left))
        {
            this.gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(this.right))
        {
            this.gameObject.transform.Translate(speed * Time.deltaTime,0, 0);
        } 

        if(rotate)
        {
            this.gameObject.transform.Rotate(new Vector3(0,0,Time.deltaTime * 100));
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player") || collision.gameObject.name.Equals("Player2")) {
            //Do nothing
        } else if (collision.gameObject.name.Equals("Star")){
            UIManager.round++;
            gm.starGenerated = false;
            Destroy(GameObject.Find("Star"));

        } else {
            animator.SetBool("isHit", true);
            Debug.Log(collision.gameObject.name);
            rotate = true;
            StartCoroutine(gameOverAnimation());

        }
    }

    // Wait two seconds then start game over animation
    private IEnumerator gameOverAnimation()
    {
        yield return new WaitForSeconds(2);
        UIManager.isGameOver = true;
    }


    
    void CalculateBounds()
    {
        // Calculate the camera bounds in world space
        Vector3 topLeftCorner = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane));
        Vector3 bottomRightCorner = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane));

        // Calculate the min and max bounds
        minBounds = topLeftCorner;
        maxBounds = bottomRightCorner;
       
    }

}



