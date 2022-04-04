using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FastTouch()
    {
        SceneManager.LoadScene("Fast_touch");
    }
    public void PingPong()
    {
        SceneManager.LoadScene("Ping Pong");
    }
    public void BallAdvanture()
    {
        SceneManager.LoadScene("BallAdvanture");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
