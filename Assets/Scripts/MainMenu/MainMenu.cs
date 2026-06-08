using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [Header("Panels")]
    public GameObject settingsPanel;

    [Header("Audio")]
    public Slider musicSlider;
    public Toggle musicToggle;

    private float lastVolume = 1f;
    private bool updatingUI = false;

    void Start() {
        AudioListener.volume = 1f;
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;

        updatingUI = true;
        if (musicSlider != null) musicSlider.value = 10f;
        if (musicToggle != null) musicToggle.isOn = true;
        updatingUI = false;
    }

    public void PlayGame() {
        SceneManager.LoadScene("GameScene-ALU");
    }

    public void OpenSettings() {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings() {
        settingsPanel.SetActive(false);
    }

    public void SetVolume(float volume) {
        if (updatingUI) return;
        AudioListener.volume = volume / 10f;
        if (volume > 0f) lastVolume = volume / 10f;
    }

    public void ToggleMusic(bool isOn) {
        if (updatingUI) return;
        updatingUI = true;
        if (isOn) {
            AudioListener.volume = lastVolume;
            if (musicSlider != null) musicSlider.value = lastVolume * 10f;
        } else {
            lastVolume = AudioListener.volume > 0f ? AudioListener.volume : lastVolume;
            AudioListener.volume = 0f;
            if (musicSlider != null) musicSlider.value = 0f;
        }
        updatingUI = false;
    }

    public void QuitGame() {
        Application.Quit();
    }

} // class