using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAd : MonoBehaviour
{
    public static GameManagerAd gm;

    int lives=3;
    float time;
    int score;

    public GameObject gameOverScene;

    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        Time.timeScale = 1;
        gameOverScene.SetActive(false);
        gm = this;
        time = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.timeSinceLevelLoad;
        GameScene.intance.ShowLives(lives);
        GameScene.intance.ShowTime(time);
        GameScene.intance.ShowScore(score);
        if (lives <= 0) OutofLive();
    }

    public void Die()
    {
        lives -= 1;
    }
    public void Score()
    {
        score += 1;
    }
    void OutofLive()
    {
        gameOverScene.SetActive(true);
        Time.timeScale = 0;
    }
}
