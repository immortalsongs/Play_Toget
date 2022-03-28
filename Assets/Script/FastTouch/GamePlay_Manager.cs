using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay_Manager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    private Rigidbody2D rg1;
    private Rigidbody2D rg2;

    public float dist = 0.3f;
    public float speed = 100f;
    [SerializeField]
    private float WinPoint;

    public float time = 30f;
    public Text timer, Victory;

    public Button button1, button2, startGame_Button;

    public int fontWin = 12;
    public int fontDraw = 15;

    public Canvas PauseMenu, EndGameMenu;


    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.gameObject.SetActive(false);
        EndGameMenu.gameObject.SetActive(false);
        startGame_Button.gameObject.SetActive(true);

        rg1 = Player1.GetComponent<Rigidbody2D>();
        rg2 = Player2.GetComponent<Rigidbody2D>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            timer.text = Mathf.Round(time).ToString();
        }
        else
        {
            EndGame();
        }
        
    }

    public void Player1_Click()
    {
        //Vector3 des = new Vector3(Player1.transform.position.x, Player1.transform.position.y - dist, Player1.transform.position.z);
        //Player1.transform.position = Vector3.Lerp(Player1.transform.position, des, Time.deltaTime * speed);

        rg1.AddForce(new Vector2(0, -speed));
        
    }

    public void Player2_Click()
    {
        //Vector3 des = new Vector3(Player2.transform.position.x, Player2.transform.position.y + dist, Player2.transform.position.z);
        //Player2.transform.position = Vector3.Lerp(Player2.transform.position, des, Time.deltaTime * speed);

        rg2.AddForce(new Vector2(0, +speed));
        
    }

    void EndGame()
    {
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        Time.timeScale = 0;

        EndGameMenu.gameObject.SetActive(true);

        WinPoint = Player1.transform.localScale.y/2;
        if (Player1.transform.position.y > WinPoint)
        {
            timer.fontSize = fontWin;
            Victory.text = "Blue win!";
        }
        else if (Player1.transform.position.y < WinPoint)
        {
            timer.fontSize = fontWin;
            Victory.text = "Pink win!";
        }
        else
        {
            timer.fontSize = fontDraw;
            Victory.text = "Draw";
        }
    }
    public void ReMatch()
    {
        PauseMenu.gameObject.SetActive(false);
        EndGameMenu.gameObject.SetActive(false);
        SceneManager.LoadScene("Fast_touch");
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseMenu.gameObject.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.gameObject.SetActive(false);
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        startGame_Button.gameObject.SetActive(false);
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        time = 0;
        EndGame();
    }

}
