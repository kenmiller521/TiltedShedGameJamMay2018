using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
/// <summary>
/// To access camera, use "ProCamera2D.Instance", then your methods/functions
/// </summary>
public class CameraController : MonoBehaviour {
    public List<GameObject> players;
	// Use this for initialization
	void Start () {
		foreach(GameObject player in players)
        {
            ProCamera2D.Instance.AddCameraTarget(player.transform, 1f, 1f, 0f);
        }
	}
}
