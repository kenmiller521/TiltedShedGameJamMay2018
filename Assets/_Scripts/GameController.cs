using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController instance;

	// Use this for initialization
	void Awake () {
		if(instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
