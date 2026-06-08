using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour {

    public TextMeshProUGUI timerText;
    public float timeRemaining = 120f; // 2 minutes

    private bool timerRunning = true;

    void Update() {
        if (timerRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            } else {
                timeRemaining = 0;
                timerRunning = false;
                UpdateTimerDisplay(0);
                // Time is up — game over
                FindAnyObjectByType<GameOverPanel>().ShowGameOver();
            }
        }
    }

    void UpdateTimerDisplay(float time) {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

} // class