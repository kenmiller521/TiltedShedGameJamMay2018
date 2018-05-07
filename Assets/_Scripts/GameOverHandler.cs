using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour {
    public GameObject GameOverScreen;
    public GameObject player1, player2; 

    void Start() {
        GameController.instance.onVictory += HandleVictoryCanvas;
    }

    /// <summary>
    /// recieves the onVictory event to enable the final screens
    /// </summary>
    /// <param name="player"></param>
    private void HandleVictoryCanvas(int player) {
        GameOverScreen.SetActive(true);
        if(player == 0) {
            player1.SetActive(true);
        }
        if(player == 1) {
            player2.SetActive(true);
        }
    }

    public void replay() {
        SceneManager.LoadScene("Arena");
    }
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
