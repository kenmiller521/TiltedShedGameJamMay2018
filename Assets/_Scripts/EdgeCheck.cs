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
		if((player1.transform.position - ArenaCenter.position).sqrMagnitude > ArenaSize * ArenaSize) {

        }
	}
}
