using UnityEngine;

/// <summary>
/// handles the collectables for each player
/// Joel Lee
/// </summary>
public class PlayerPickUpHandler : MonoBehaviour {
    private int PickUpCount;
    //playercontroller

    public void IncrementCount() {
        PickUpCount++;
        AdjustPlayer();
    }

    public void DecrementSize() {
        PickUpCount--;
    }

    public void AdjustPlayer() {
        //playercontroller.changestats(pickupcount)
    }

}
