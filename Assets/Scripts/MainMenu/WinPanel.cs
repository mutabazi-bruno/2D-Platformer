using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour {

    public GameObject winPanel;

    void Start() {
        winPanel.SetActive(false);
    }

    public void ShowWin() {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
    }

    public void Replay() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

} // class