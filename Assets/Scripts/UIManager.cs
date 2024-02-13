using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
 
    [SerializeField] private TextMeshProUGUI score;
    private GameObject player;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button resumeButton;
    [SerializeField] private TMPro.TextMeshPro gameOverText;
    public static int round;
    public static bool isGameOver;
    private bool isPause;



    // Start is called before the first frame update
    void Start()
    {
        round = 0;
        isGameOver = false;
        isPause = false;

        TMPro.TextMeshPro pauseText = new TMPro.TextMeshPro();
        pauseText.text = "PAUSED";
       
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

    public void updateScore()
    {
        string newText = "Score: " + round.ToString();
        score.SetText(newText);
       // Debug.Log(score.text);

    }

    public void gameOver()
    {

        //gameOverText.text = "Game Over!\n Score: " + UIManager.round;
        SceneManager.LoadScene("GameOverScene");
        gameOverText.text = "Game Over!\n Score: " + round;

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
