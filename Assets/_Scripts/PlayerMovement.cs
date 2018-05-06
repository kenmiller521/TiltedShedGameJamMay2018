using System.Collections;
using UnityEngine;

/// <summary>
///
/// Ruben Sanchez
/// 
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private KeyCode Up;

    [SerializeField]
    private KeyCode Left;

    [SerializeField]
    private KeyCode Down;

    [SerializeField]
    private KeyCode Right;

    [SerializeField]
    private KeyCode Boost;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float boostSpeedMultiplier;

    [Tooltip("In Seconds")]
    [SerializeField]
    private float boostDuration;

    private bool isBoosting; // do not allow steering during boost
    private Rigidbody2D rigidB;
    private Vector2 moveDirection;
    private Vector2 boostDirection;
    private Coroutine boostCoroutine;

    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        if (!isBoosting)
        {
             moveDirection = Vector2.zero;

            if (Input.GetKey(Up))
                moveDirection.y++;

            if (Input.GetKey(Down))
                moveDirection.y--;

            if (Input.GetKey(Right))
                moveDirection.x++;

            if (Input.GetKey(Left))
                moveDirection.x--;

            moveDirection = Vector3.Normalize(moveDirection);

            rigidB.velocity = moveDirection * moveSpeed;
            transform.right = moveDirection;
        }

        if (Input.GetKeyDown(Boost))
        {
            if (boostCoroutine == null)
            {
                isBoosting = true;
                boostCoroutine = StartCoroutine(BoostCo());
            }
           


        }

       
    }

    public void ChangeSpeed(float amount)
    {
        moveSpeed += amount;
    }

    public IEnumerator BoostCo()
    {
        boostDirection = moveDirection;
        rigidB.velocity = moveSpeed * boostSpeedMultiplier * boostDirection;
        yield return new WaitForSeconds(boostDuration);
        isBoosting = false;
        boostCoroutine = null;
    }
}
