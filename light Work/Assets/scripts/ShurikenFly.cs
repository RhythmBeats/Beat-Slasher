using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenFly : MonoBehaviour
{
    public float speed;

    public float speedRotate;

    public GameObject spawnPoint;

    Vector2 targetPosition = new Vector2(0, 0);

    public Vector2 originalPosition;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        
        startTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime < 4f/3f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
             if(this.gameObject.transform.childCount > 0) transform.GetChild(0).Rotate(-Vector3.forward*2);
        }
        else{
            Destroy(gameObject);
        }
    }
}
