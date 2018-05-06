using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour { 
    public delegate void OnPickUpEvent();
    public event OnPickUpEvent OnPickUp;

    void OnCollisionEnter2D(Collision2D c) {
        PlayerPickUpHandler temp = c.gameObject.GetComponent<PlayerPickUpHandler>();
        if (temp != null) {
            temp.IncrementCount();
            OnPickUp();
        }
    }
}
