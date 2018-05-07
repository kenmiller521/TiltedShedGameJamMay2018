using UnityEngine;

/// <summary>
/// Checks for inBounds
/// Ruben Sanchez
/// 
/// </summary>

public class InBoundsDetector : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D playerCollider;

    [SerializeField]
    private CircleCollider2D boundryCollider;

    [SerializeField] private LayerMask boundryLayer;



	void Update ()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerCollider.transform.position, playerCollider.radius, boundryLayer);

        if (colliders.Length == 0)
            Destroy(gameObject);
    }
}
