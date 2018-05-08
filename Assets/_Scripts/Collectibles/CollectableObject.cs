using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// an object that is supposed to be collected by the player
/// </summary>
public class CollectableObject : MonoBehaviour { 
    public delegate void OnPickUpEvent();
    public event OnPickUpEvent OnPickUp;

    [SerializeField]
    private List<Sprite> collectableSprites;

    public void Start()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = collectableSprites[Random.Range(0, collectableSprites.Count-1)];
    }
    void OnTriggerEnter2D(Collider2D c) {
        PlayerPickUpHandler temp = c.GetComponent<PlayerPickUpHandler>();
        if (temp != null)
        {
       
            //sound trigger
            temp.ChangeSize(+1);
            if (OnPickUp != null) OnPickUp();

            Destroy(gameObject);
        }
    }
}
