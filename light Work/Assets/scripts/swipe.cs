using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    public Animator animator;
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    Collider2D closest;

    public Transform attackPos1;
    public Transform attackPos2;
    public Transform attackPos3;
    public Transform attackPos4;
    public Transform attackPos5;
    public Transform attackPos6;
    public float attackRangeX1;
    public float attackRangeY1;
    public float attackRangeX2;
    public float attackRangeY2;
    public float attackRangeX3;
    public float attackRangeY3;
    public float attackRangeX4;
    public float attackRangeY4;
    public float attackRangeX5;
    public float attackRangeY5;
    public float attackRangeX6;
    public float attackRangeY6;
    public LayerMask whatIsEnemies;
    void Start()
    {
        dragDistance = Screen.height * 5 / 100; //dragDistance is 5% height of the screen
    }

    void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 10% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check the 6 direction swipes
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y) && Mathf.Abs(lp.y-fp.y) < dragDistance)
                    {   //Left or Right
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            animator.SetTrigger("SlashRight");
                            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos1.position, new Vector2(attackRangeX1, attackRangeY1), whatIsEnemies);
                            if (enemiesToDamage.Length != 0)
                            {
                                closest = enemiesToDamage[0];

                                for (int i = 0; i < enemiesToDamage.Length; i++)
                                {
                                    if (enemiesToDamage[i].transform.position.x < closest.transform.position.x)
                                    {
                                        closest = enemiesToDamage[i];
                                    }
                                }
                                if (closest.transform.parent.gameObject != null) Destroy(closest.transform.parent.gameObject);
                            }
                            
                        }
                        else
                        {   //Left swipe
                        //gotta fix this shit, the left swipe hit box is detecting theres always something in it, i suspect it's picking up the players hitbox
                            animator.SetTrigger("SlashLeft");
                            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos2.position, new Vector2(attackRangeX2, attackRangeY2), whatIsEnemies);
                            if (enemiesToDamage.Length != 0) 
                            {
                                closest = enemiesToDamage[0];

                                for (int i = 0; i < enemiesToDamage.Length; i++)
                                {
                                    if (enemiesToDamage[i].transform.position.x > closest.transform.position.x)
                                    {
                                        closest = enemiesToDamage[i];
                                    }
                                }
                                Debug.Log(enemiesToDamage.Length);
                                if (closest.transform.parent.gameObject != null) Destroy(closest.transform.parent.gameObject);
                            }
                            
                        }
                    }
                    else if (lp.x < fp.y && Mathf.Abs(lp.y - fp.y) > dragDistance) 
                    //condition for top && bottom left
                    {   
                        if (lp.y > fp.y)  //movement was upwards
                        {   //Top Left swipe
                            animator.SetTrigger("SlashTopLeft");
                            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos3.position, new Vector2(attackRangeX3, attackRangeY3),135f, whatIsEnemies);
                            if (enemiesToDamage.Length != 0)
                            {
                                closest = enemiesToDamage[0];

                                for (int i = 0; i < enemiesToDamage.Length; i++)
                                {
                                    if (enemiesToDamage[i].transform.position.x > closest.transform.position.x)
                                    {
                                        closest = enemiesToDamage[i];
                                    }
                                }
                                if (closest.transform.parent.gameObject != null) Destroy(closest.transform.parent.gameObject);
                            }
                        }
                        else
                        {   //Bottom Left swipe
                            animator.SetTrigger("SlashDownLeft");
                            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos4.position, new Vector2(attackRangeX4, attackRangeY4),225f, whatIsEnemies);
                            if (enemiesToDamage.Length != 0)
                            {
                                closest = enemiesToDamage[0];

                                for (int i = 0; i < enemiesToDamage.Length; i++)
                                {
                                    if (enemiesToDamage[i].transform.position.x > closest.transform.position.x)
                                    {
                                        closest = enemiesToDamage[i];
                                    }
                                }
                                if (closest.transform.parent.gameObject != null) Destroy(closest.transform.parent.gameObject);
                            }
                        }
                    }
                    else if (lp.x > fp.y && Mathf.Abs(lp.y - fp.y) > dragDistance)
                    //condition for top && bottom right
                    { 
                        if (lp.y > fp.y)  //movement was upwards
                        {   //Top Right swipe
                           animator.SetTrigger("SlashTopRight");
                            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos5.position, new Vector2(attackRangeX5, attackRangeY5),45f, whatIsEnemies);
                            if (enemiesToDamage.Length != 0)
                            {
                                closest = enemiesToDamage[0];

                                for (int i = 0; i < enemiesToDamage.Length; i++)
                                {
                                    if (enemiesToDamage[i].transform.position.x < closest.transform.position.x)
                                    {
                                        closest = enemiesToDamage[i];
                                    }
                                }
                                if (closest.transform.parent.gameObject != null) Destroy(closest.transform.parent.gameObject);
                            }
                        }
                        else
                        {   //Bottom Right swipe
                            animator.SetTrigger("SlashDownRight");
                            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos6.position, new Vector2(attackRangeX6, attackRangeY6),315f, whatIsEnemies);
                            if (enemiesToDamage.Length != 0)
                            {
                                closest = enemiesToDamage[0];

                                for (int i = 0; i < enemiesToDamage.Length; i++)
                                {
                                    if (enemiesToDamage[i].transform.position.x < closest.transform.position.x)
                                    {
                                        closest = enemiesToDamage[i];
                                    }
                                }
                                if (closest.transform.parent.gameObject != null) Destroy(closest.transform.parent.gameObject);
                            }
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }
    }
}
