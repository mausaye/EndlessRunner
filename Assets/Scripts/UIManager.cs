using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    // UI items for pause menu and score
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button resumeButton;
    [SerializeField] private TMPro.TextMeshPro gameOverText;

    private GameObject player;
    public static float round;
    public static bool isGameOver;
    private bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        round = 0;
        isGameOver = false;
        isPause = false;

        TMPro.TextMeshPro pauseText = new TMPro.TextMeshPro();
        score.gameObject.SetActive(true);
        pauseMenu.SetActive(false);
        resumeButton.onClick.AddListener(resume);
        pauseButton.onClick.AddListener(pause);
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();

        if (isGameOver)
        {
            gameOver();
        }

       
    }

    // Updates the score based on the delta time
    public void updateScore()
    {
        round += Time.deltaTime/2;
        string newText = ((int)round).ToString();
        score.SetText(newText);
    }

    public void gameOver()
    {
        // Game over UI loaded
        SceneManager.LoadScene("GameOverScene");
        gameOverText.text = "Game Over!\n Score: " + (int)round;

    }

    public void resume()
    {
        Time.timeScale = 1;
        isPause = false;
        pauseMenu.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        pauseButton.gameObject.SetActive(false);
       
        Time.timeScale = 0;
        isPause = true;
        
    }
}
