using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// rotate an object by a speed about its center axis
/// </summary>
public class RotateObject : MonoBehaviour {
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
<<<<<<< HEAD
=======
        //Debug.Log(Time.deltaTime);
>>>>>>> 912e53c6e2d23f49b57fcbc08b2701cb0e9c8aaa
        transform.Rotate(transform.forward, RotationalSpeed * Time.timeScale);
    }

}
