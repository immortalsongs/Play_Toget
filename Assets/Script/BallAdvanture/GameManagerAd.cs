using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAd : MonoBehaviour
{
    public static GameManagerAd gm;

    const string CHECKPOINT_x = "Check point_x";
    const string CHECKPOINT_y = "Check point_y";
    const string CHECKPOINT_z = "Check point_z";

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
        BallColider.isDead = true;
        //Time.timeScale = 0;
    }

    public void SetCheckPoint(Vector3 checkpoint)
    {
        PlayerPrefs.SetFloat(CHECKPOINT_x, checkpoint.x);
        PlayerPrefs.SetFloat(CHECKPOINT_y, checkpoint.y);
        PlayerPrefs.SetFloat(CHECKPOINT_z, checkpoint.z);
    }
    public Vector3 GetCheckPoint()
    {
        Vector3 checkpoint = new Vector3(PlayerPrefs.GetFloat(CHECKPOINT_x), PlayerPrefs.GetFloat(CHECKPOINT_y), PlayerPrefs.GetFloat(CHECKPOINT_z));
        return checkpoint;
    }
}
