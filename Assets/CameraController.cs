using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    BallColider ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("ball");
        ball = player.GetComponent<BallColider>();
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10);
    }
}
