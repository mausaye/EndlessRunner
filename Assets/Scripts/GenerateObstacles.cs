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
    [SerializeField] private GameObject puffMobPreFab;
    [SerializeField] private GameObject puffPreFab;
    [SerializeField] private GameObject acornPrefab;
    [SerializeField] private GameObject throwingMobPreFab;
    [SerializeField] private GameObject obstacleGroup;
    [SerializeField] private GameObject jumpMobPrefab;
    [SerializeField] private GameObject warning;
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

    }

    // Update is called once per frame
    void Update()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        tileSize = screenHeight / numTiles;

        if (obstacleCleared){
            generateRandom();
            incrementRound();
        }

        if (this.obstacleGroup.transform.childCount == 0 && !obstacleCleared)
        {
            obstacleCleared = true;
        }
    }

    void generateRandom()
    {
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
        yield return new WaitForSeconds(seconds);
        var obj = Instantiate(jumpMobPrefab, new Vector3(7, -5, 0), Quaternion.identity);
        obj.AddComponent<Jump>();
        obj.transform.parent = this.obstacleGroup.transform;

    }
    void generateJumpMod()
    {
        obstacleCleared = false;
        var warningObj = Instantiate(warning, new Vector3(7, -4, 0), Quaternion.identity);
        Destroy(warningObj, 1);
        StartCoroutine(delayInstantiate(1));

    }

    void generatePuffMod(int y)
    {
        obstacleCleared = false;
        var obj = Instantiate(puffMobPreFab, new Vector3(7, y, 0), Quaternion.identity);
        var puffObj = obj.AddComponent<PoofBehavior>();
        puffObj.puffPrefab = puffPreFab;
        puffObj.puffMob = obj;
        obj.transform.parent = this.obstacleGroup.transform;

    }
    void generateThrowingMod()
    {
        obstacleCleared = false;
        var obj = Instantiate(throwingMobPreFab, new Vector3(7, -5, 0), Quaternion.identity);
        var throwObj = obj.AddComponent<ThrowingBehavior>();
        throwObj.acornPrefab = acornPrefab;
        throwObj.throwingMob = obj;
        obj.transform.parent = this.obstacleGroup.transform;
    }

    void createObstacle()
    {
        obstacleCleared = false;
        int randV = Random.Range(-4, -1);
        int randV2 = Random.Range(-1, 2);
        int randV3 = Random.Range(2, 5);

        var obj = Instantiate(obstaclePreFab, new Vector3(10, randV, 0), Quaternion.identity);
        var obj2 = Instantiate(obstaclePreFab, new Vector3(10, randV2, 0), Quaternion.identity);
        var obj3 = Instantiate(obstaclePreFab, new Vector3(10, randV3, 0), Quaternion.identity);

        obj.transform.parent = this.obstacleGroup.transform;
        obj2.transform.parent = this.obstacleGroup.transform;
        obj3.transform.parent = this.obstacleGroup.transform;
    }

    public void incrementRound()
    {
        UIManager.round++;
    }

}
