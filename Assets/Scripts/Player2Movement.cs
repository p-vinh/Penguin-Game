using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// same player controller as P1 but is binded to arrow keys
public class Player2Movement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    bool jump = false;

    public Animator animator;
    public Rigidbody2D rigidBody2D;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump2"))
        {
            animator.SetBool("IsJumping", true);
            jump = true;
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }

        if (rigidBody2D.position.y < -10f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
