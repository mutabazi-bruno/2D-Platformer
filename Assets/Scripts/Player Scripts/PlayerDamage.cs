using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour {

	private Text lifeText;
	private int lifeScoreCount;
	private bool canDamage;
	private SpriteRenderer sr;

	private Vector3 lastSafePosition;

	void Awake () {
		lifeText = GameObject.Find ("LifeText").GetComponent<Text> ();
		lifeScoreCount = 3;
		lifeText.text = "x" + lifeScoreCount;
		canDamage = true;
		sr = GetComponent<SpriteRenderer>();
	}

	void Start() {
		Time.timeScale = 1f;
		lastSafePosition = transform.position;
	}

	void Update() {
		if (transform.position.y > -2f) {
			lastSafePosition = transform.position;
		}
	}
	
	public void DealDamage() {
		if (canDamage) {
			
			lifeScoreCount--;

			if (lifeScoreCount >= 0) {
				lifeText.text = "x" + lifeScoreCount;
			}

			if (lifeScoreCount <= 0) {
				// No lives left — show game over panel
				FindAnyObjectByType<GameOverPanel>().ShowGameOver();
			} else {
				// Lives remain — respawn near water
				StartCoroutine(Respawn());
			}

			StartCoroutine(HitFlash());
			canDamage = false;
			StartCoroutine(WaitForDamage());
		}
	}

	IEnumerator Respawn() {
		GetComponent<PlayerMovement>().enabled = false;
		GetComponent<Rigidbody2D>().gravityScale = 0f;
		GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

		yield return new WaitForSeconds(1f);

		transform.position = new Vector3(lastSafePosition.x, lastSafePosition.y + 1f, lastSafePosition.z);

		GetComponent<Rigidbody2D>().gravityScale = 2.3f;
		GetComponent<PlayerMovement>().enabled = true;
	}

	IEnumerator HitFlash() {
		for (int i = 0; i < 6; i++) {
			sr.color = new Color(1f, 0.2f, 0.2f, 0.5f);
			yield return new WaitForSeconds(0.1f);
			sr.color = Color.white;
			yield return new WaitForSeconds(0.1f);
		}
		sr.color = Color.white;
	}

	IEnumerator WaitForDamage() {
		yield return new WaitForSeconds(2f);
		canDamage = true;
	}

} // class