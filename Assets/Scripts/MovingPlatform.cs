using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pos1, pos2;
    public Transform startPosition;
    public float speed;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position) {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position) {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player") || target.gameObject.CompareTag("Player2")) {
            target.transform.parent = this.gameObject.transform;
        }
    }



    private void OnCollisionExit2D(Collision2D target) {
        if (target.gameObject.CompareTag("Player") || target.gameObject.CompareTag("Player2")) {
            target.transform.parent = null;
        }
    }
}
