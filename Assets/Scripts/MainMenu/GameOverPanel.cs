using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour {

    public GameObject gameOverPanel;   

    void Start() {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver() {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    // Called by Replay button
    public void Replay() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Called by Quit button
    public void Quit() {
        SceneManager.LoadScene("MainMenu");
    }

} // class