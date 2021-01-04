using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenFly : MonoBehaviour
{
    public float speed;

    public GameObject spawnPoint;

    Vector2 targetPosition = new Vector2(0, 0);

    public Vector2 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            //animator.Play("Skeleton Dead");
            Destroy(gameObject);
        }
    }
}
