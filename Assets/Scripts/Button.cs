using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Do something with this
public class Button : MonoBehaviour, Interactable {
    SpriteRenderer spriteRenderer;
    public Animator animator;
    [SerializeField] Color32 goalColor = new Color32(0, 0, 0, 255);

    enum state
    {
        ON,
        OFF
    }

    private int state_ = (int) state.ON;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public int getState() {
        return state_;
    }
    public void Active() {
        gameObject.SetActive(false);
        animator.SetBool("IsPressed", true);

    }
    public void Inactive() {
        gameObject.SetActive(true);
        animator.SetBool("IsPressed", false);
    }

    public void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Player" || target.gameObject.tag == "Player2") {
            test();
        }
    }

    public void test()
    {
        spriteRenderer.color = goalColor;
    }
}