using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int redPoint, greenPoint;

    public BallControl ball;
    public Text redScore, greenScore, victory;

    public Canvas pauseMenu, victoryMenu;


    // Start is called before the first frame update
    void Start()
    {
        victoryMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        redPoint = 0;
        greenPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        redScore.text = redPoint.ToString();
        greenScore.text = greenPoint.ToString();
        if (redPoint >= 3 || greenPoint >= 3) EndGame();
    }

    public void RedScore()
    {
        redPoint++;
        ball.ResetPos();
    }
    public void GreenScore()
    {
        greenPoint++;
        ball.ResetPos();
    }

    public void EndGame()
    {
        victoryMenu.gameObject.SetActive(true);
        if (redPoint >= 3)
        {
            victory.text = "Red victory";
            victoryMenu.transform.Rotate(0,0,90);
        }
        else victory.text = "Green victory";
    }

    public void PauseMenu()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Rematch()
    {
        victoryMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        redPoint = 0;
        greenPoint = 0;

        ball.ResetPos();
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

}
