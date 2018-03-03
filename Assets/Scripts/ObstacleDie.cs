using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDie : MonoBehaviour {

    private Animator animator;
    private Collider2D collider2D;

	void Start () {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();

    }
	
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Monster") {
            animator.SetTrigger("Die");
            Destroy(collider2D);
            var temp = target.transform.position;
            temp.x += 0.5f;
            target.transform.position = temp;
        }
    }

    void OnDieEnd() {
        gameObject.SetActive(false);
    }
}
