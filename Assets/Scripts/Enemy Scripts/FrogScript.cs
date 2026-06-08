using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour {

    private Animator anim;
    private bool animation_Started;
    private bool animation_Finished;
    private int jumpedTimes;
    private bool jumpLeft = true;
    private string coroutine_Name = "FrogJump";
    public LayerMask playerLayer;
    private GameObject player;
    private bool isDead = false;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    void Start() {
        StartCoroutine(coroutine_Name);
        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
    }

    void Update() {
        if (isDead) return;

        if (Physics2D.OverlapCircle(transform.position, 0.5f, playerLayer)) {
            player.GetComponent<PlayerDamage>().DealDamage();
        }
    }

    void LateUpdate() {
        if (animation_Finished && animation_Started) {
            animation_Started = false;
            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
    }

    // Bullet hits the frog
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == MyTags.BULLET_TAG) {
            isDead = true;
            StopAllCoroutines();
            anim.Play("FrogDead");
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }

    IEnumerator FrogJump() {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        animation_Started = true;
        animation_Finished = false;
        jumpedTimes++;

        if (jumpLeft) {
            anim.Play("FrogJumpLeft");
        } else {
            anim.Play("FrogJumpRight");
        }

        StartCoroutine(coroutine_Name);
    }

    void AnimationFinished() {
        animation_Finished = true;

        if (jumpLeft) {
            anim.Play("FrogIdleLeft");
        } else {
            anim.Play("FrogIdleRight");
        }

        if (jumpedTimes == 3) {
            jumpedTimes = 0;
            Vector3 tempScale = transform.localScale;
            tempScale.x *= -1;
            transform.localScale = tempScale;
            jumpLeft = !jumpLeft;
        }
    }

} // class