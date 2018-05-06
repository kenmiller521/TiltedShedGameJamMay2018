using UnityEngine;

/// <summary>
/// Manages player size with local scale
///
/// Ruben Sanchez
/// 
/// </summary>

public class PlayerSize : MonoBehaviour
 {
     [SerializeField]
     private Vector2 startingLocalScale = Vector2.one;

     [SerializeField]
     private Vector2 minLocalScale = Vector2.one;

    [SerializeField]
     private float scaleChangeSize = .5f;

     private void Awake()
     {
         transform.localScale = startingLocalScale;
     }

     public void IncreaseSize()
     {
        transform.localScale = new Vector2(transform.localScale.x + scaleChangeSize, transform.localScale.y + scaleChangeSize);
     }

     public void DecreaseSize()
     {
         transform.localScale = new Vector2(transform.localScale.x - scaleChangeSize, transform.localScale.y - scaleChangeSize);

         if (transform.localScale.magnitude < minLocalScale.magnitude)
             transform.localScale = minLocalScale;
     }


 }
