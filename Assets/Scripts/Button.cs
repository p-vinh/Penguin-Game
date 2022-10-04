using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Do something with this
public class Button : MonoBehaviour {
    
    public Animator animator;
    public PlatformEffector2D platformEffector2D;
    public SpriteRenderer spriteRenderer;
    [SerializeField] Color32 hitPlayerColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hitPlayer2Color = new Color32(1, 1, 1, 1);
    //GroundColor groundScript;

    enum state
    {
        ON,
        OFF
    }
    
    [SerializeField]
    private int state_ = (int) state.ON;

    void Start()
    {
       // groundScript = GetComponentInParent<GroundColor>();
       platformEffector2D = GetComponentInParent<PlatformEffector2D>();
       spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    public int getState() {
        return state_;
    }

    public void ActiveBlue() {
        gameObject.SetActive(false);
        spriteRenderer.color = hitPlayerColor;
        gameObject.layer = 9;
        platformEffector2D.colliderMask = 128;
        //platform.changeToPink();
        state_ = (int) state.ON;

        // animator.SetBool("IsPressed", true);
    }
    public void ActivePink() {
        gameObject.SetActive(false);
       // groundScript.changeToBlue();
        state_ = (int) state.ON;
        // animator.SetBool("IsPressed", false);
    }

    public void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Player") {
            ActiveBlue();
        }
        if (target.gameObject.tag == "Player2") {
            ActivePink();
        }
    }

    public void OnCollisionExit2D(Collision2D target) {
        

    }

}