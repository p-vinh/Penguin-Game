using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Later Project
public class Portal : MonoBehaviour
{
    public Transform portal1, portal2;
    
    Vector2 startPosition, endPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = portal1.position;
        endPosition = portal2.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.tag == "Player" || target.gameObject.tag == "Player2") {
            
        }
    }
}
