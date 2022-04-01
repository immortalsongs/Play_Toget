using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{

    public Text txtLives, txtTime, txtScore;
    public static GameScene intance;

    // Start is called before the first frame update
    void Start()
    {
        intance = gameObject.GetComponent<GameScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("BallAdvanture");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShowLives(int lives)
    {
        txtLives.text = "Lives left: " +lives.ToString();
    }

    public void ShowScore(int score)
    {
        txtScore.text = "Score: " + score.ToString();
    }

    public void ShowTime(float time)
    {
        float minute = Mathf.FloorToInt(time / 60);
        float second = Mathf.FloorToInt(time % 60);
        txtTime.text= "Time: "+ string.Format("{0:00}:{1:00}", minute, second);
    }
}
