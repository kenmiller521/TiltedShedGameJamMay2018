using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour {

    public void replay() {
        SceneManager.LoadScene("Arena");
    }
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
