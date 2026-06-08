using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

	private float speed = 10f;
	private Animator anim;
	private bool canMove;

	void Awake() {
		anim = GetComponent<Animator>();
	}

	void Start () {
		canMove = true;
		StartCoroutine(DisableBullet(5f));
	}

	void Update () {
		Move();
	}

	void Move() {
		if (canMove) {
			Vector3 temp = transform.position;
			temp.x += speed * Time.deltaTime;
			transform.position = temp;
		}
	}

	public float Speed {
		get { return speed; }
		set { speed = value; }
	}

	IEnumerator DisableBullet(float timer) {
		yield return new WaitForSeconds(timer);
		gameObject.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D target) {
		// Hit enemy
		if (target.tag == MyTags.BEETLE_TAG || target.tag == MyTags.SNAIL_TAG
			|| target.tag == MyTags.SPIDER_TAG || target.tag == MyTags.BOSS_TAG
			|| target.tag == MyTags.FROG_TAG) {
			anim.Play("Explode");
			canMove = false;
			StartCoroutine(DisableBullet(0.1f));
		}

		// Hit ground or walls — stop bullet
		if (target.gameObject.layer == LayerMask.NameToLayer("Ground")) {
			canMove = false;
			gameObject.SetActive(false);
		}
	}

} // class