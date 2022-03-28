using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Two : MonoBehaviour
{
    Rigidbody2D rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        Vector3 temp = transform.localScale;

        float height = sr.bounds.size.y;
        float width = sr.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(worldWidth, worldHeight, 0);

        temp.y = worldHeight / height;
        temp.x = worldWidth / width / 1.2f;
        transform.localScale = temp;
        transform.position = new Vector3(0, -temp.y / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            rg.AddForce(new Vector2(0, 50));
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Finish")
    //    {
    //        Time.timeScale = 0;
    //    }
    //}
}
