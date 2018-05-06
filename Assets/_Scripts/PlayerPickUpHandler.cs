using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// handles the collectables for each player
/// Joel Lee
/// </summary>
public class PlayerPickUpHandler : MonoBehaviour
{
    [SerializeField]
    private float scaleChangeAmount = .3f;

    [SerializeField]
    private UnityEvent onPickup;

    private int _pickUpCount;
    ChangeSizeEvent AdjustSpeed;
    private Transform player;

    private PlayerMovement playerMovement;

    void Start() {
        AdjustSpeed = new ChangeSizeEvent();
        player = GetComponentInChildren<SpriteRenderer>().transform;
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    public int PickUpCount {
        get { return _pickUpCount; }
        set { _pickUpCount = value; }
    }
    /// <summary>
    /// Changes the amount of pickups we are carrying up to an amount
    /// Fires off the adjust speed event on the player
    /// recieves the change size event from the player
    /// </summary>
    /// <param name="amount"></param>
    public void ChangeSize(int amount) {
        _pickUpCount -= amount;
        onPickup.Invoke();
        
        //AdjustSpeed.Invoke(_pickUpCount);

    }

}

public class ChangeSizeEvent : UnityEvent<int>
{

}
