using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPosition;
    public Transform pos1, pos2;
    Vector3 nextPos;
    public float speed = 2;


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
}
