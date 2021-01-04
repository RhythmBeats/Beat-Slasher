using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Animator animator;

    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            animator.SetBool("SlashDownLeft", true);
        }
        if (Input.GetKeyUp(key))
        {
            animator.SetBool("SlashDownLeft", true);
        }
    }
}
