using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Brackeys player Controller I used P1 is on WASD

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    bool jump = false;

    public Animator animator;
    public Rigidbody2D rigidBody2D;
    public Transform transform;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
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
           
         if (rigidBody2D.position.y < -10f)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }

    // public void OnCollisionEnter2D(Collision2D target) {
    //     if (target.gameObject.CompareTag("Player2")) {
    //         target.transform.position += Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D target) {
    //     if (target.gameObject.CompareTag("Player2")) {
    //         target.transform.parent = null;
    //     }
    // }
}
