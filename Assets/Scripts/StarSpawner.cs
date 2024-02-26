using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private GameObject starGroup;
    GameManager gm;
    Canvas starCanvas;
    private int randomIterations;
    private int roundCounter = 0;
    private GameObject currentStar;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        starGroup.AddComponent<Canvas>();
        starCanvas = starGroup.GetComponent<Canvas>();
        starCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        starCanvas.worldCamera = Camera.main;
        randomIterations = Random.Range(2, 3);
      
    }

    // Update is called once per frame
    void Update()
    {
        
        if (randomIterations - UIManager.round == 0 && !gm.starGenerated)
        {
            generateStar();
            gm.starGenerated = true;
            randomIterations = UIManager.round + Random.Range(2, 3);
        }
      
    }

    void generateStar()
    {
        currentStar = Instantiate(starPrefab, new Vector3(Random.Range(-4,4), Random.Range(-4, 4), 0), Quaternion.identity);
        currentStar.transform.parent = this.starGroup.transform;
        currentStar.name = "Star";
    }
}
