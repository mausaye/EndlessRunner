using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    // Game Over UI
    [SerializeField] private Button exitButton;
    [SerializeField] private Button playAgainButton;
    private GameManager gm;
    
    void Start()
    {
        gm = GameManager.Instance;
        exitButton.onClick.AddListener(exitGame);
        playAgainButton.onClick.AddListener(playAgain);

    }

    void playAgain()
    {
        gm.playAgain();
    }

    void exitGame()
    {
        Application.Quit();
    }
}
