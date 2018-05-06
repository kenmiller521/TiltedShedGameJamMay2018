using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// rotate an object by a speed about its center axis
/// </summary>
public class RotateObject_NET : NetworkBehaviour {
    public float RotationalSpeed = 2.5f;
    public bool RandomSpeed = false;
    public float RandomModifier = 10f;

    void Start() {
        if (Random.Range(0, 2) == 1) {
            RotationalSpeed = -RotationalSpeed;
        }
        
        if (RandomSpeed) {
            RotationalSpeed += Random.Range(-RandomModifier, RandomModifier);
        }
    }

    void Update() {
        transform.Rotate(transform.forward, RotationalSpeed);
    }

}
