using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColider : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    public float force=10f;
    public float speed = 10f;
    float horizontalMove = 0;

    public bool isJump;

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed*Time.deltaTime;
        if (Mathf.Abs(rb.velocity.magnitude) < 5)
        {
            rb.velocity += Vector2.right * horizontalMove;

            if (Input.GetButtonDown("Jump"))
            {
                if (!isJump)
                {
                    rb.AddForce(Vector2.up * force);
                    isJump = true;
                }
            }

            if (!Input.anyKey)
            {
                rb.velocity = rb.velocity * 0.95f;
                //rb.AddForce(Vector2.down * 20);
            }
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //rb.AddForce(Vector2.up*500);
        if (collision.gameObject.tag == "death")
        {
            GameManagerAd.gm.Die();
            transform.position = new Vector3(-2.17f, -0.95f, 0);
        }

        if (collision.gameObject.tag == "floor")
        {
            isJump = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //luc dang va cham nhau
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Luc roi nhau ra
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="coin")
        {
            GameManagerAd.gm.Score();
        }
    }

}
