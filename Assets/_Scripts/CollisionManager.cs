using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Com.LuisPedroFonseca.ProCamera2D;
/// <summary>
/// Applies force on collision depending on pickup count
/// Ruben Sanchez
/// 
/// </summary>

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onMiss;

    public static float forceScaleMultiplier = 50f;

    [SerializeField]
    private UnityEvent onCollision;

    private Rigidbody2D rigidB;

    private PlayerPickUpHandler pickUpHandler;
    private PlayerMovement playerMovement;
    private string tagToCompare = "Player";
    private bool hit = false, inMissWindow = false;
    private float timePassed;
    private void Awake()
    {
        rigidB = GetComponentInParent<Rigidbody2D>();
        pickUpHandler = GetComponent<PlayerPickUpHandler>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        if (inMissWindow) {
            timePassed += Time.deltaTime;
            if (hit) {
                timePassed = 0f;
                inMissWindow = false;
            }
            else if(timePassed > playerMovement.BoostDuration + 0.5f) {
                timePassed = 0f;
                inMissWindow = false;
                onMiss.Invoke();
            }
        }
    }

    public void StartMissCheck() {
        inMissWindow = true;
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
                    ProCamera2D.Instance.GetComponent<ProCamera2DShake>().Shake(.3f, new Vector2(difference, difference), 2, 0f, Vector3.Angle(this.transform.position, other.gameObject.transform.position), default(Vector3), .1f);
                    onCollision.Invoke();
                    
                    Vector2 direction = Vector3.Normalize(other.transform.position - transform.position);

                    otherPickUpHandler.GetComponentInParent<Rigidbody2D>()
                        .AddForce(direction * difference * forceScaleMultiplier);

                    other.gameObject.GetComponent<PlayerHealth>().DecrementHealth();

                    hit = true;
                }
            }

        }
       
    }
}
