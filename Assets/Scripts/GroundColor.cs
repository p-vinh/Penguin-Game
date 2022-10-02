using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script changes the platform color, and by doing so allows the player of that color to walk on that platform and players of the other color to just 
// fall through
public class GroundColor : MonoBehaviour
{
    [SerializeField] Color32 hitPlayerColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hitPlayer2Color = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;
    PlatformEffector2D platformEffector2D;
   

    void Start()
        // the comments in the body are just notes, I tried some stuff and it wouldn't work
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        platformEffector2D = GetComponent<PlatformEffector2D>();
        
       // if (tag == "Blue") 
            {
            //spriteRenderer.color = hitPlayerColor;
           // gameObject.layer = 9;
            }
       // if (tag == "Pink")
        {
            //spriteRenderer.color = hitPlayer2Color;
           // gameObject.layer = 10;
        }

    }

    
    void OnCollisionEnter2D(Collision2D target)
    {
       // if (tag == "Untagged")
      //  {
            if (target.gameObject.tag == "Player")
            {
                spriteRenderer.color = hitPlayerColor;
                gameObject.layer = 9;
                platformEffector2D.colliderMask = 128;
            }
            else if (target.gameObject.tag == "Player2")
            {
                spriteRenderer.color = hitPlayer2Color;
                gameObject.layer = 10;
                platformEffector2D.colliderMask = 264;

            }
       // }
       
    }
   
}
