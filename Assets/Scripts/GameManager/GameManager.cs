using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [Header("Player")]
    public GameObject player;
    private SpriteRenderer playerSprite;

    [Header("Respawn")]
    private Vector3 lastSafePosition;
    public float respawnOffsetX = 2f;
    public float respawnOffsetY = 2f;

    [Header("End Screen")]
    public GameObject endScreenUI;

    [Header("Hit Effect")]
    public int flashCount = 6;
    public float flashInterval = 0.1f;

    private bool isRespawning = false;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        if (endScreenUI != null)
            endScreenUI.SetActive(false);

        if (player != null) {
            lastSafePosition = player.transform.position;
            playerSprite = player.GetComponent<SpriteRenderer>();
        }
    }

    void Update() {
        // Track last safe position above water
        if (player != null && !isRespawning) {
            if (player.transform.position.y > 0f) {
                lastSafePosition = player.transform.position;
            }
        }
    }

    // Called by WaterScript when player falls in
    public void PlayerFellInWater(float waterEntryX) {
        if (isRespawning) return;

        // Let PlayerDamage handle life deduction
        player.GetComponent<PlayerDamage>().DealDamage();

        StartCoroutine(RespawnPlayer(waterEntryX));
    }

    public void PlayerHitByEnemy() {
        StartCoroutine(HitFlashEffect());
    }

    IEnumerator HitFlashEffect() {
        if (playerSprite == null) yield break;

        for (int i = 0; i < flashCount; i++) {
            playerSprite.color = new Color(1f, 0.2f, 0.2f, 0.5f);
            yield return new WaitForSeconds(flashInterval);
            playerSprite.color = Color.white;
            yield return new WaitForSeconds(flashInterval);
        }

        playerSprite.color = Color.white;
    }

    IEnumerator RespawnPlayer(float waterEntryX) {
        isRespawning = true;

        StartCoroutine(HitFlashEffect());
        player.GetComponent<PlayerMovement>().enabled = false;

        yield return new WaitForSeconds(1f);

        Vector3 respawnPos = new Vector3(
            waterEntryX - respawnOffsetX,
            lastSafePosition.y + respawnOffsetY,
            player.transform.position.z
        );

        player.transform.position = respawnPos;
        player.GetComponent<PlayerMovement>().enabled = true;

        isRespawning = false;
    }

    public void ShowEndScreen() {
        Time.timeScale = 0f;
        if (endScreenUI != null)
            endScreenUI.SetActive(true);
    }

    public void ReplayGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame() {
        Application.Quit();
    }

} // class