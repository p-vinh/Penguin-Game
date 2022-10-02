using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable {

    int getState();
    void Active();
    void Inactive();
    void OnCollisionEnter2D(Collision2D target);
    void OnCollisionExit2D(Collision2D target);

}
