using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
/// <summary>
/// an object that is supposed to be collected by the player
/// </summary>
public class CollectableObject_NET : NetworkBehaviour { 
    public delegate void OnPickUpEvent();
    public event OnPickUpEvent OnPickUp;

    void OnTriggerEnter2D(Collider2D c) {
        PlayerPickUpHandler temp = c.GetComponent<PlayerPickUpHandler>();
        if (temp != null) {
            //sound trigger
            temp.ChangeSize(+1);
            if (OnPickUp != null) OnPickUp();
            Destroy(gameObject);
        }
    }
}
