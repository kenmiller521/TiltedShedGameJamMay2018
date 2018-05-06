using UnityEngine;

/// <summary>
/// Applies force on collision depending on pickup count
/// Ruben Sanchez
/// 
/// </summary>

public class CollisionManager : MonoBehaviour
{
    public static float forceScaleMultiplier = 200f;

    private Rigidbody2D rigidB;

    private PlayerPickUpHandler pickUpHandler;
    private string tagToCheck = "Player";

    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
        pickUpHandler = GetComponent<PlayerPickUpHandler>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(tagToCheck))
        {
            PlayerPickUpHandler otherPickUpHandler = other.gameObject.GetComponent<PlayerPickUpHandler>();            

  
            int difference = pickUpHandler.PickUpCount - otherPickUpHandler.PickUpCount;

            //if other planet is smaller
            if (difference > 0)
            {
                print("reeeee");
                //you were boosting
                if (GetComponentInParent<PlayerMovement>() != null && GetComponentInParent<PlayerMovement>().isBoosting)
                {
                    Vector2 direction = Vector3.Normalize(other.transform.position - transform.position);

                    otherPickUpHandler.GetComponentInParent<Rigidbody2D>().AddForce(direction * forceScaleMultiplier);
                    GetComponentInParent<PlayerMovement>().Knock();
                }
            }
        }
    }
}
