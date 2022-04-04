using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallColider : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    public Animator ani;

    public float force=10f;
    public float speed = 10f;
    float horizontalMove = 0;

    static public bool isDead;

    public bool isJump;

    bool isPress;

    Transform checkpoint;
    

    private void Start()
    {
        transform.position = GameManagerAd.gm.GetCheckPoint();
        Debug.Log(GameManagerAd.gm.GetCheckPoint());
        isDead = false;
        isPress = false;
    }

    private void Update()
    {
        
        if (!isDead)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            if (Mathf.Abs(rb.velocity.magnitude) <= 5)
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


            }
            if (/*!Input.anyKey &&*/ !isPress)
            {
                rb.velocity = rb.velocity * 0.95f;

                //rb.AddForce(Vector2.down * 20);
            }
        }
    }

    public void MoveLeft()
    {
        isPress = true;
        if (Mathf.Abs(rb.velocity.magnitude) <= 5)
            rb.velocity += Vector2.right * -1 * 2;
    }
    public void MoveRight()
    {
        isPress = true;
        if (Mathf.Abs(rb.velocity.magnitude) <= 5)
            rb.velocity += Vector2.right * 2;

    }
    public void Jump()
    {
        if (!isJump)
        {
            rb.AddForce(Vector2.up * force);
            isJump = true;
        }
    }

    public void ButtonUp()
    {
        isPress = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //rb.AddForce(Vector2.up*500);
        if (collision.gameObject.tag == "death")
        {
            GameManagerAd.gm.Die();
            StartCoroutine(Die());
            
        }

        if (collision.gameObject.tag == "floor")
        {
            isJump = false;
        }
    }

    IEnumerator Die()
    {
        ani.SetBool("die", true);
        yield return new WaitForSeconds(0.4f);
        transform.position = checkpoint.position;
        ani.SetBool("die", false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //luc dang va cham nhau
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Luc roi nhau ra
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="coin")
        {
            GameManagerAd.gm.Score();
        }
        if(collision.gameObject.tag=="CheckPoint")
        {
            checkpoint = collision.transform;
            GameManagerAd.gm.SetCheckPoint(collision.transform.position);
        }
    }

}
