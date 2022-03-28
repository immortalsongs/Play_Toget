using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAd : MonoBehaviour
{
    public static GameManagerAd gm;

    int lives=3;
    float time;

    public GameObject gameOverScene;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOverScene.SetActive(false);
        gm = this;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.realtimeSinceStartup;
        GameScene.intance.ShowLives(lives);
        GameScene.intance.ShowTime(time);
        if (lives <= 0) OutofLive();
    }

    public void Die()
    {
        
        lives -= 1;
    }
    void OutofLive()
    {
        gameOverScene.SetActive(true);
        Time.timeScale = 0;
    }
}
