using UnityEngine;

/// <summary>
///
/// Ruben Sanchez
/// 
/// </summary>

public class EdgeCheck : MonoBehaviour
{
    public float ArenaSize = 25f;
    public Transform ArenaCenter; 
    public GameObject player1, player2;

	void Update () 
	{
        //cheap way to handle distance checking for OOB
		if((player1.transform.position - ArenaCenter.position).sqrMagnitude > ArenaSize * ArenaSize) {
            GameController.instance.HandleWin(1);
        }
        if((player2.transform.position - ArenaCenter.position).sqrMagnitude > ArenaSize * ArenaSize) {
            GameController.instance.HandleWin(0);
        }
	}
}
