using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   
    [SerializeField] private Button howToPlayButton;
    [SerializeField] private GameObject howToPlayMenu;
    [SerializeField] private Button returnButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private Button singleButton;
    [SerializeField] private Button multiButton;


    // Start is called before the first frame update
    void Start()
    {

        howToPlayMenu.SetActive(false);
        howToPlayButton.onClick.AddListener(showHowToPlay);
        returnButton.onClick.AddListener(returnMain);
        this.gameObject.SetActive(true);
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
        howToPlayMenu.SetActive(true);
        returnButton.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    void returnMain()
    {
        howToPlayMenu.SetActive(false);
        returnButton.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }

    void exitGame()
    {
        Application.Quit();
    }
}
