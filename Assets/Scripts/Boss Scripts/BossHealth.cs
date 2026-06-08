using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

	private Animator anim;
	private int health = 9;
	private bool canDamage;

	void Awake () {
		anim = GetComponent<Animator>();
		canDamage = true;
	}

	IEnumerator WaitForDamage() {
		yield return new WaitForSeconds(0.5f);
		canDamage = true;
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (canDamage) {
			if (target.tag == MyTags.BULLET_TAG) {
				health--;
				canDamage = false;

				if (health <= 0) {
					GetComponent<BossScript>().DeactivateBossScript();
					anim.Play("BossDead");
					StartCoroutine(ShowWinScreen());
				}

				StartCoroutine(WaitForDamage());
			}
		}
	}

	IEnumerator ShowWinScreen() {
		yield return new WaitForSeconds(1.5f);
		FindAnyObjectByType<WinPanel>().ShowWin();
	}

} // class