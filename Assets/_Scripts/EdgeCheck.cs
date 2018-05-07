using UnityEngine;

/// <summary>
///
/// Ruben Sanchez
/// 
/// </summary>

public class EdgeCheck : MonoBehaviour
{
    public CircleCollider2D boundryCollider;
	
	void Update () 
	{
		if((transform.position - boundryCollider.transform.position).magnitude > boundryCollider.radius)
            print("reeee");
	}
}
