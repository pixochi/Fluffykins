using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip coinClip;

    private int points = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Coin") {

            audioSource.PlayOneShot(coinClip);
            target.gameObject.SetActive(false);
            points++;
            GamePlayController.instance.SetScore(points);
        }
    }

}
