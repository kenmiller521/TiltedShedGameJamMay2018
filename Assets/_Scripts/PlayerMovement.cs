using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
///
/// Ruben Sanchez
/// 
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onBoost;

    [Tooltip("When the smaller player gets knocked back")]
    [SerializeField]
    private UnityEvent onKnock;

    [Tooltip("In Seconds")]
    [SerializeField]
    private float knockBackDuration;


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

    private bool isBoosting; // do not monitor input during boost
    private Coroutine boostCoroutine;

    private bool isKnocked; // do not monitor input during knockback
    private Coroutine knockCoroutine;

    private Rigidbody2D rigidB;
    private Vector2 moveDirection;
    private Vector2 boostDirection;
    

    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        if (!isBoosting && !isKnocked)
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

            rigidB.velocity = Vector2.Lerp(rigidB.velocity, moveDirection * moveSpeed, Time.deltaTime);
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
        onBoost.Invoke();
        boostDirection = moveDirection;
        rigidB.velocity = Vector2.Lerp(rigidB.velocity, moveSpeed * boostSpeedMultiplier * boostDirection, Time.deltaTime);
        yield return new WaitForSeconds(boostDuration);
        isBoosting = false;
        boostCoroutine = null;
    }

    public void Knock()
    {
        if (knockCoroutine == null)
        {
            isKnocked = true;
            knockCoroutine = StartCoroutine(KnockCo());
        }
    }

    public IEnumerator KnockCo()
    {
        yield return new WaitForSeconds(knockBackDuration);
        isKnocked = false;
        knockCoroutine = null;
    }
}
