using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    float playerSize = 1;
    float speed = 15;

    static int SIZE = 50;
    private Camera mainCamera;
    private Vector3 minBounds;
    private Vector3 maxBounds;
    private Vector3 objectSize;

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
        
    }

    // Update is called once per frame
    void Update() {

        // Ensure player does not go outside of the camera bounds
        if (this.gameObject.transform.position.y < maxBounds.y) { this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, maxBounds.y, 0);  }
        else if (this.gameObject.transform.position.x < minBounds.x) { this.gameObject.transform.position = new Vector3(minBounds.x, this.gameObject.transform.position.y, 0); }
        else if (this.gameObject.transform.position.y > minBounds.y) { this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, minBounds.y, 0); }
        else if (this.gameObject.transform.position.x > maxBounds.x) { this.gameObject.transform.position = new Vector3(maxBounds.x, this.gameObject.transform.position.y, 0); }


        if (Input.GetKey(this.up)) {
            this.gameObject.transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(this.down)){
            // this.y = this.y - 1;
            this.gameObject.transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(this.left))
        {
            // this.y = this.y - 1;
            this.gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(this.right))
        {
            // this.y = this.y - 1;
            this.gameObject.transform.Translate(speed * Time.deltaTime,0, 0);
        } 
//        Debug.Log(Screen.width + " " + Screen.height);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player")) {
            //Do nothing
        } else if (collision.gameObject.name.Equals("Star")){
            UIManager.round++;
            gm.starGenerated = false;
            Destroy(GameObject.Find("Star"));

        } else {
            animator.SetBool("isHit", true);
            Debug.Log(collision.gameObject.name);
            StartCoroutine(gameOverAnimation());
        }
        
    }

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

        // Get the object's size
        objectSize = this.gameObject.GetComponent<Collider>().bounds.size / 2;

        // Calculate the min and max bounds
        minBounds = topLeftCorner;
        maxBounds = bottomRightCorner;
       
    }

}



