using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform spawnPoint5;
    public Transform spawnPoint6;

    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        System.Random rand = new System.Random();

        rand.Next(0, 10);

        if (rand < 5)
        {
            return;
        }
        if(rand ==6)
        {
            Instantiate(gameObject, spawnPoint1);
        }
        if (rand == 7)
        {
            Instantiate(gameObject, spawnPoint2);
        }
        if (rand == 8)
        {
            Instantiate(gameObject, spawnPoint3);
        }
        if (rand == 9)
        {
            Instantiate(gameObject, spawnPoint4);
        }

        i++;
        if (i == 100)
        {
            Debug.Break();
        }
    }
}
