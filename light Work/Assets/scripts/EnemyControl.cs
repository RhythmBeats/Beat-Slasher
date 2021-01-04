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
    public int Case;

    public Sprite shuriken;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Case = UnityEngine.Random.Range(0, 10);
        if (Case < 5)
        {
            return;
        }
        if(Case == 6)
        {
            Instantiate(shuriken, spawnPoint1);
        }
        if (Case == 7)
        {
            Instantiate(shuriken, spawnPoint2);
        }
        if (Case == 8)
        {
            Instantiate(shuriken, spawnPoint3);
        }
        if (Case == 9)
        {
            Instantiate(shuriken, spawnPoint4);
        }

        i++;
        if (i == 30)
        {
            Debug.Break();
        }
    }
}
