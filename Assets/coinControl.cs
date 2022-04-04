using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinControl : MonoBehaviour
{
    public Animator ani;
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(playAni());
    }
    IEnumerator playAni()
    {
        ani.SetBool("isTaken", true);
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}

