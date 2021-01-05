using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Animator animator;

    public KeyCode key1;
    public KeyCode key2;

    public bool sDL = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key1) && animator.GetBool("SlashDownLeft") == false)
        {
            animator.SetBool("SlashDownLeft", true);
        }
        else
        {
            animator.SetBool("SlashDownLeft", false);
        }
        if (Input.GetKeyDown(key2) && animator.GetBool("SlashDownRight") == false)
        {
            animator.SetBool("SlashDownRight", true);
        }
        else
        {
            animator.SetBool("SlashDownRight", false);
        }
           
    }
}
