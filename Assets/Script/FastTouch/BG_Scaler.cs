using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BG_Scaler : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        Vector3 temp = transform.localScale;

        float height = sr.bounds.size.y;
        float width = sr.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(worldWidth, worldHeight);

        temp.y = worldHeight / height;
        temp.x = worldWidth / width;
        transform.localScale = temp;
    }
    // Update is called once per frame
}
