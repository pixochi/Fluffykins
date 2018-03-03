using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    private float jumpForce = 7.5f, forwardForce = 0f;
    private bool canJump = true;
    private bool canSlide = true;
    private int numberOfJumps = 0;
    private float colliderSizeOnSlide = 0.85f;

    private float colliderOffset = 0;
    private Rigidbody2D movingBody;
    private BoxCollider2D bodyCollider;
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip jumpClip, slideClip;

    void Awake() {
        movingBody = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update () {

        if (movingBody.velocity.y == 0) {

            numberOfJumps = 0;
            canSlide = true;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            if (Input.GetTouch(0).position.x <= (Screen.width / 2)) {
                // user clicked on the left half of screen
                Jump();
            } else {
                // user clicked on the right half of screen
                Slide();
            }
        }
    }

    private void Jump() {
        if (canJump && numberOfJumps < 2) {
            canSlide = false;
            numberOfJumps++;

            audioSource.PlayOneShot(jumpClip);
            animator.SetTrigger("Jump");

            forwardForce = (movingBody.transform.position.x < 0) ? 1f : 0f;
            movingBody.velocity = new Vector2(forwardForce, jumpForce);  
        }
    }

    private void Slide() {
        if (canSlide) {
            canJump = false;
            canSlide = false;
            audioSource.PlayOneShot(slideClip);
            animator.SetTrigger("Slide");
        }   
    }

    private void OnSlideEnd() {
        canSlide = true;
        canJump = true;
    }

    private void OnJumpEnd() {
        canJump = true;
    }
}
