using UnityEngine;

/// <summary>
/// Applies force on collision depending on pickup count
/// Ruben Sanchez
/// 
/// </summary>

public class CollisionManager : MonoBehaviour
{
    private Rigidbody2D rigidB;

    private void Awake()
    {
        rigidB = GetComponentInParent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        throw new System.NotImplementedException();
    }
}
