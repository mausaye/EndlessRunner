using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    // Star prefabs
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private GameObject starGroup;

    GameManager gm;

    Canvas starCanvas;
    private GameObject currentStar;

    // Number of rounds until star reappears
    private int randomIterations;

    void Start()
    {
        // Init game manager, canvas, and set random iterations
        gm = GameManager.Instance;
        starGroup.AddComponent<Canvas>();
        starCanvas = starGroup.GetComponent<Canvas>();
        starCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        starCanvas.worldCamera = Camera.main;
        randomIterations = Random.Range(2, 3);
      
    }

    void Update()
    {
        // Checks if the number of iterations has passed, generate star if so
        if (randomIterations - UIManager.round == 0 && !gm.starGenerated)
        {
            generateStar();
            gm.starGenerated = true;
            randomIterations = (int)UIManager.round + Random.Range(2, 3);
        }
      
    }

    void generateStar()
    {
        currentStar = Instantiate(starPrefab, new Vector3(Random.Range(-4,4), Random.Range(-4, 4), 0), Quaternion.identity);
        currentStar.layer = LayerMask.NameToLayer("UI");
        currentStar.transform.parent = this.starGroup.transform;
        currentStar.name = "Star";
    }
}
