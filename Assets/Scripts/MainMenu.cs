using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    // Buttons and title icons
    [SerializeField] private Button howToPlayButton;
    [SerializeField] private GameObject howToPlayMenu;
    [SerializeField] private Button returnButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject title;
    [SerializeField] private Button singleButton;
    [SerializeField] private Button multiButton;

    void Start()
    {
        // Menu items
        howToPlayMenu.SetActive(false);
        this.gameObject.SetActive(true);
        title.SetActive(true);

        // Button event listeners
        howToPlayButton.onClick.AddListener(showHowToPlay);
        returnButton.onClick.AddListener(returnMain);
        exitButton.onClick.AddListener(exitGame);
        singleButton.onClick.AddListener(singlePlayerGame);
        multiButton.onClick.AddListener(multiplayerGame);

    }

    void singlePlayerGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    void multiplayerGame()
    {
        GeneratePlayer.numPlayers = 2;
        SceneManager.LoadScene("GameScene");
    }

    void showHowToPlay()
    {
        // When showing how to play remove all other items from UI
        howToPlayMenu.SetActive(true);
        returnButton.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        title.SetActive(false);
    }

    void returnMain()
    {
        // Remove how to play UI and put back other items
        howToPlayMenu.SetActive(false);
        returnButton.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        title.SetActive(true);
    }

    void exitGame()
    {
        Application.Quit();
    }
}
