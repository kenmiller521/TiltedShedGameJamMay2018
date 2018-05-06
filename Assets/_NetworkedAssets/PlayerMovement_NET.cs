using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
/// <summary>
///
/// Ruben Sanchez
/// 
/// </summary>

public class PlayerMovement_NET : NetworkBehaviour {
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

    [SyncVar]
    [SerializeField]
    private float moveSpeed;

    [SyncVar]
    [SerializeField]
    private float boostSpeedMultiplier;

    [Tooltip("In Seconds")]
    [SyncVar]
    [SerializeField]
    private float boostDuration;

    [SyncVar]
    private bool isBoosting; // do not monitor input during boost
    private Coroutine boostCoroutine;
    [SyncVar]
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

    [Command]
    public void ChangeSpeed(float amount)
    {
        moveSpeed += amount;
    }

    [Command]
    public IEnumerator BoostCo()
    {
        onBoost.Invoke();
        boostDirection = moveDirection;
        rigidB.velocity = Vector2.Lerp(rigidB.velocity, moveSpeed * boostSpeedMultiplier * boostDirection, Time.deltaTime);
        yield return new WaitForSeconds(boostDuration);
        isBoosting = false;
        boostCoroutine = null;
    }

    [ClientRpc]
    public void Knock()
    {
        if (knockCoroutine == null)
        {
            isKnocked = true;
            knockCoroutine = StartCoroutine(KnockCo());
        }
    }

    [Command]
    public IEnumerator KnockCo()
    {
        yield return new WaitForSeconds(knockBackDuration);
        isKnocked = false;
        knockCoroutine = null;
    }
}
