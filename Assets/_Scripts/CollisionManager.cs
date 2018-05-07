using UnityEngine;

/// <summary>
/// Applies force on collision depending on pickup count
/// Ruben Sanchez
/// 
/// </summary>

public class CollisionManager : MonoBehaviour
{
    public static float forceScaleMultiplier = 40f;

    private Rigidbody2D rigidB;

    private PlayerPickUpHandler pickUpHandler;
    private PlayerMovement playerMovement;
    private string tagToCompare = "Player";

    private void Awake()
    {
        rigidB = GetComponentInParent<Rigidbody2D>();
        pickUpHandler = GetComponent<PlayerPickUpHandler>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
      
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(tagToCompare))
        {
            if (other.gameObject.GetComponentInChildren<PlayerPickUpHandler>() != null)
            {

                PlayerPickUpHandler otherPickUpHandler = other.gameObject.GetComponentInChildren<PlayerPickUpHandler>();
                int difference = otherPickUpHandler.pickUpCount - pickUpHandler.pickUpCount;

                //if other planet is smaller and you were boosting
                if (difference > 0 && playerMovement.isBoosting)
                {
                    Vector2 direction = Vector3.Normalize(other.transform.position - transform.position);

                    otherPickUpHandler.GetComponentInParent<Rigidbody2D>()
                        .AddForce(direction * difference * forceScaleMultiplier);

                }
            }

        }
       
    }
}
