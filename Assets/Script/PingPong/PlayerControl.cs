using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            Vector3 playerPos = rb.position;
            if (Mathf.Abs(touchPos.x - playerPos.x) < 0.5f && Mathf.Abs(touchPos.y - playerPos.y) < 0.5f)
            {
                rb.position = touchPos;
            }
        }
        rb.velocity = Vector3.zero;
    }


}
