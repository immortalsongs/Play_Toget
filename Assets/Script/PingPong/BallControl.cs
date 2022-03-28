using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float thurstForce;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            thurstForce += 10;
            rb.velocity=((transform.position - collision.transform.position).normalized*thurstForce*Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "red goal") gameManager.GreenScore();
        if (collision.gameObject.tag == "green goal") gameManager.RedScore();
    }

    public void ResetPos()
    {
        rb.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector2.zero);
    }
}
