using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class GenerateObstacles : MonoBehaviour
{
    int screenWidth;
    int screenHeight;
    static int numTiles = 10;
    float tileSize;
    float offset;
    [SerializeField] private GameObject obstaclePreFab;
    [SerializeField] private GameObject acornPrefab;
    [SerializeField] private GameObject throwingMobPreFab;
    [SerializeField] private GameObject obstacleGroup;
    [SerializeField] private GameObject jumpMobPrefab;
    GameObject[] mobs;
    private static int numMobs = 3;
    Canvas obCanvas;
    public static bool obstacleCleared;

    // Start is called before the first frame update
    void Start()
    {
        obstacleGroup.AddComponent<Canvas>();
        obCanvas = obstacleGroup.GetComponent<Canvas>();
        obCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        obCanvas.worldCamera = Camera.main;

        obstacleCleared = true;

        mobs = new GameObject[numMobs];
        mobs[0] = obstaclePreFab;
        mobs[1] = throwingMobPreFab;
        mobs[2] = jumpMobPrefab;

    }

    // Update is called once per frame
    void Update()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        tileSize = screenHeight / numTiles;

        if (obstacleCleared){
            //generateJumpMod();
            //createObstacle();
            generateThrowingMod();
            incrementRound();
        }

        if (this.obstacleGroup.transform.childCount == 0 && !obstacleCleared)
        {
            obstacleCleared = true;
           
        }

    }

    void generateJumpMod()
    {
        obstacleCleared = false;
        var obj = Instantiate(jumpMobPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        obj.AddComponent<Jump>();
        //obj.AddComponent<ObstacleMovement>();
        obj.transform.parent = this.obstacleGroup.transform;
        //obj.transform.localScale = new Vector3(tileSize, tileSize, tileSize);

    }

    void generateThrowingMod()
    {
        obstacleCleared = false;
        var obj = Instantiate(throwingMobPreFab, new Vector3(0, -5, 0), Quaternion.identity);
        var throwObj = obj.AddComponent<ThrowingBehavior>();
        
        throwObj.acornPrefab = acornPrefab;
        throwObj.throwingMob = obj;
        //obj.AddComponent<ObstacleMovement>();
        obj.transform.parent = this.obstacleGroup.transform;
        //obj.transform.localScale = new Vector3(tileSize, tileSize, tileSize);
    }

        void createObstacle()
    {
        obstacleCleared = false;
        int randV = Random.Range(0, numTiles);

        // for (int i = 0; i <= 1; i++)
        //{ 
        //   if (i == randV || i == randV + 1) continue;
        
        var obj = Instantiate(obstaclePreFab, new Vector3(10,0, 0), Quaternion.identity);
        
        obj.transform.parent = this.obstacleGroup.transform;
       
        // obj.transform.localScale = new Vector3(tileSize, tileSize, tileSize);
        // }



    }

    public void incrementRound()
    {
        UIManager.round++;
    }

}
