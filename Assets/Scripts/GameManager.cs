using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
 
    public static GameManager Instance;
    public bool starGenerated;

    public void Awake()
    {
        if (!Instance) Instance = this;
    }

    // Keeps track of star generation
    void Start()
    {
        starGenerated = false;
    }

    // Play again event
    public void playAgain()
    {
        SceneManager.LoadScene("GameScene");

        UIManager.round = 0;
        UIManager.isGameOver = false;

    }




}
