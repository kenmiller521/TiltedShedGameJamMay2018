using UnityEngine;

public class PlayerPickUpHandler : MonoBehaviour {
    private int PickUpCount;
    //playercontroller

    public void IncrementCount() {
        PickUpCount++;
    }

    public void DecrementSize() {
        PickUpCount--;
    }

    public void AdjustPlayer() {
        //playercontroller.changestats(pickupcount)
    }

}
