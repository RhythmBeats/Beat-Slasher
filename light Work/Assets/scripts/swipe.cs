using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    public Animator animator;
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

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
                            if (animator.GetBool("SlashRight") == false)
                            {
                                animator.SetBool("SlashRight", true);
                            }
                            else
                            {
                                animator.SetBool("SlashRight", false);
                            }
                        }
                        else
                        {   //Left swipe
                            if (animator.GetBool("SlashLeft") == false)
                            {
                                animator.SetBool("SlashLeft", true);
                            }
                            else
                            {
                                animator.SetBool("SlashLeft", false);
                            }
                        }
                    }
                    else if (lp.x < fp.y && Mathf.Abs(lp.y - fp.y) > dragDistance) 
                    //condition for top && bottom left
                    {   
                        if (lp.y > fp.y)  //movement was upwards
                        {   //Top Left swipe
                            if (animator.GetBool("SlashTopLeft") == false)
                            {
                                animator.SetBool("SlashTopLeft", true);
                            }
                            else
                            {
                                animator.SetBool("SlashTopLeft", false);
                            }
                        }
                        else
                        {   //Bottom Left swipe
                            if (animator.GetBool("SlashDownLeft") == false)
                            {
                                animator.SetBool("SlashDownLeft", true);
                            }
                            else
                            {
                                animator.SetBool("SlashDownLeft", false);
                            }
                        }
                    }
                    else if (lp.x > fp.y && Mathf.Abs(lp.y - fp.y) > dragDistance)
                    //condition for top && bottom right
                    { 
                        if (lp.y > fp.y)  //movement was upwards
                        {   //Top Right swipe
                            if (animator.GetBool("SlashTopRight") == false)
                            {
                                animator.SetBool("SlashTopRight", true);
                            }
                            else
                            {
                                animator.SetBool("SlashTopRight", false);
                            }
                        }
                        else
                        {   //Bottom Right swipe
                            if (animator.GetBool("SlashDownRight") == false)
                            {
                                animator.SetBool("SlashDownRight", true);
                            }
                            else
                            {
                                animator.SetBool("SlashDownRight", false);
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
