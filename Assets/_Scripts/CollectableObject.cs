using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// an object that is supposed to be collected by the player
/// </summary>
public class CollectableObject : MonoBehaviour { 
    public delegate void OnPickUpEvent();
    public event OnPickUpEvent OnPickUp;

    void OnTriggerEnter2D(Collider2D c) {
        PlayerPickUpHandler temp = c.GetComponent<PlayerPickUpHandler>();
        if (temp != null) {
            //sound trigger
            temp.ChangeSize(+1s);
            OnPickUp();
            Destroy(gameObject);
        }
    }
}
