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
    [SerializeField] private GameObject obstacleGroup;
    [SerializeField] private GameObject jumpMobPrefab;
    Canvas obCanvas;
    public static bool obstacleCleared;
    
    // Start is called before the first frame update
    void Start()
    {
        obstacleGroup.AddComponent<Canvas>();
        obCanvas = obstacleGroup.GetComponent<Canvas>();
        //obstacleGroup.AddComponent<CanvasScaler>();
        //obstacleGroup.AddComponent<GraphicRaycaster>();
        obCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        obCanvas.worldCamera = Camera.main;

        obstacleCleared = true;
      

    }

    // Update is called once per frame
    void Update()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        tileSize = screenHeight / numTiles;

        if (obstacleCleared){
            //generateJumpMod();
            createObstacle();
        }

        if (this.gameObject.transform.childCount == 0)
        {
            obstacleCleared = true;
        }

    }

    void generateJumpMod()
    {
        obstacleCleared = false;
        var obj = Instantiate(jumpMobPrefab, new Vector3(0, -5, 0), Quaternion.identity);
       // obj.AddComponent<Jump>();
        obj.AddComponent<ObstacleMovement>();
        obj.transform.parent = this.gameObject.transform;
        obj.transform.localScale = new Vector3(tileSize, tileSize, tileSize);

    }

    void createObstacle()
    {
        obstacleCleared = false;
        int randV = Random.Range(0, numTiles);
        
        for (int i = 0; i <= 1; i++)
        { 
            if (i == randV || i == randV + 1) continue;

           
            var obj = Instantiate(obstaclePreFab, new Vector3(10,0, 0), Quaternion.identity);
        
            obj.transform.parent = this.gameObject.transform;
           // obj.transform.localScale = new Vector3(tileSize, tileSize, tileSize);
        }

        incrementRound();
    }

    public void incrementRound()
    {
        UIManager.round++;
    }

}
