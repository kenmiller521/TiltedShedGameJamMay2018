using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameController : MonoBehaviour {
    public static GameController instance;

    public delegate void VictoryEvent(int player);
    public event VictoryEvent onVictory;
	// Use this for initialization
	void Awake () {
        instance = this;

    }

    /// <summary>
    /// handles the gameover state
    /// </summary>
    /// <param name="player"></param> the player who won
    public void HandleWin(int player) {
        onVictory(player);
    }

}
