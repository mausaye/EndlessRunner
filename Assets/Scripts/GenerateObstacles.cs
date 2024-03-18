using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class GenerateObstacles : MonoBehaviour
{
    // All possible obstacles
    [SerializeField] private GameObject cloud1;
    [SerializeField] private GameObject cloud2;
    [SerializeField] private GameObject cloud3;
    [SerializeField] private GameObject cloud4;
    [SerializeField] private GameObject cloud5;
    [SerializeField] private GameObject cloud6;
 //  [SerializeField] private GameObject obstaclePreFab;
    [SerializeField] private GameObject puffMobPreFab;
    [SerializeField] private GameObject puffPreFab;
    [SerializeField] private GameObject acornPrefab;
    [SerializeField] private GameObject throwingMobPreFab;
    [SerializeField] private GameObject obstacleGroup;
    [SerializeField] private GameObject jumpMobPrefab;
    [SerializeField] private GameObject warning;

    // Canvas obstacles are generated on
    Canvas obCanvas;

    // Store obstacles into an array
    private GameObject[] clouds;

    private GameManager gm;

    void Start()
    {
        gm = GameManager.Instance;

        // Initialize canvas
        obstacleGroup.AddComponent<Canvas>();
        obCanvas = obstacleGroup.GetComponent<Canvas>();
        obCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        obCanvas.worldCamera = Camera.main;

        // Initialize obstacles and store for easy access
        clouds = new GameObject[6];
        clouds[0] = cloud1;
        clouds[1] = cloud2;
        clouds[2] = cloud3;
        clouds[3] = cloud4;
        clouds[4] = cloud5;
        clouds[5] = cloud6;

    }

    void Update()
    {
        // Generates obstacles if there are less than 4 on the screen
        if (this.obstacleGroup.transform.childCount < 4) generateRandom();
    }

    void generateRandom()
    {
        // Randomly selects which squirrel mob to generate
        int random = Random.Range(0, 3);
        createObstacle();

        switch (random)
        {
            case 0:
                generateJumpMod();
                break;
            case 1:
                generatePuffMod(Random.Range(-4,4));
                break;
            case 2:
                generateThrowingMod();
                break;
        }
        
    }

    IEnumerator delayInstantiate(int seconds)
    {
        // Delays the creation of jump mob so a warning can generate first
        yield return new WaitForSeconds(seconds);
        var obj = Instantiate(jumpMobPrefab, new Vector3(7, -5, 0), Quaternion.identity);
        obj.layer = LayerMask.NameToLayer("UI");
        obj.AddComponent<Jump>();
        obj.transform.parent = this.obstacleGroup.transform;

    }
    void generateJumpMod()
    {
        // Generates warning
        var warningObj = Instantiate(warning, new Vector3(Random.Range(5,7), -4, 0), Quaternion.identity);
        Destroy(warningObj, 1);

        // Generates jump mob
        StartCoroutine(delayInstantiate(1));

    }

    void generatePuffMod(int y)
    {
        // Generates puff mob
        var obj = Instantiate(puffMobPreFab, new Vector3(10, y, 0), Quaternion.identity);
        obj.layer = LayerMask.NameToLayer("UI");
        var puffObj = obj.AddComponent<PoofBehavior>();
        puffObj.puffPrefab = puffPreFab;
        puffObj.puffMob = obj;
        obj.transform.parent = this.obstacleGroup.transform;

    }
    void generateThrowingMod()
    {
        // Generates throwing mob
        var obj = Instantiate(throwingMobPreFab, new Vector3(10, -4, 0), Quaternion.identity);
        obj.layer = LayerMask.NameToLayer("UI");
        var throwObj = obj.AddComponent<ThrowingBehavior>();
        throwObj.acornPrefab = acornPrefab;
        throwObj.throwingMob = obj;
        obj.transform.parent = this.obstacleGroup.transform;
    }

    void createObstacle()
    {
        // Randomly generates 3 obstacles somewhere on the screen x,y are randomized
        for(int i = 0; i < 3; i++)
        {
            var obj = Instantiate(clouds[Random.Range(0, 5)], new Vector3(Random.Range(25, 55), Random.Range(-5, 6), 0), Quaternion.identity);
            obj.transform.parent = this.obstacleGroup.transform;
        }
    }

}
