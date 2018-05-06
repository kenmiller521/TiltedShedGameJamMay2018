using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
/// <summary>
/// handles the collectables for each player
/// Joel Lee
/// </summary>
public class PlayerPickUpHandler_NET : NetworkBehaviour {
    [SyncVar]
    private int _pickUpCount;
    [SyncVar]
    ChangeSizeEvent AdjustSpeed;

    void Start() {
        AdjustSpeed = new ChangeSizeEvent();
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
        AdjustSpeed.Invoke(_pickUpCount);
    }

}