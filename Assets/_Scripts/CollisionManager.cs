using UnityEngine;

/// <summary>
/// Applies force on collision depending on pickup count
/// Ruben Sanchez
/// 
/// </summary>

public class CollisionManager : MonoBehaviour
{
    public static float forceScaleMultiplier = 2f;

    private Rigidbody2D rigidB;

    private PlayerPickUpHandler pickUpHandler;

    private void Awake()
    {
        rigidB = GetComponentInParent<Rigidbody2D>();
        pickUpHandler = GetComponent<PlayerPickUpHandler>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerPickUpHandler>() != null)
        {
            PlayerPickUpHandler otherPickUpHandler = other.gameObject.GetComponent<PlayerPickUpHandler>();

            //if other planet is smaller
            if (otherPickUpHandler.PickUpCount < pickUpHandler.PickUpCount)
            {
                int difference = pickUpHandler.PickUpCount - otherPickUpHandler.PickUpCount;
                Vector2 direction = Vector3.Normalize(other.transform.position - transform.position);

                otherPickUpHandler.GetComponentInParent<Rigidbody2D>().AddForce(direction * forceScaleMultiplier);
            }


        }

    }
}
