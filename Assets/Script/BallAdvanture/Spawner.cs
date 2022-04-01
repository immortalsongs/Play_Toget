using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector3[] coinPlace;
    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        var numbers = MakeNewList();
        for(int i=0; i<numbers.Length;i++)
        {
            transform.position = coinPlace[numbers[i]];
            Instantiate(coin, transform.position, Quaternion.identity);
        }
    }

    int[] MakeNewList()
    {
        int randomNumber;   
        int lastNumber=16;
        var numbers = new int[10];
        for(int i=0;i<numbers.Length; i++)
        {
            randomNumber = Random.Range(0, 15);
            if (randomNumber == lastNumber)
            {
                randomNumber = Random.Range(0, 15);
            }
            else numbers[i] = randomNumber;
            lastNumber = randomNumber;
        }
        return numbers;
    }
}
