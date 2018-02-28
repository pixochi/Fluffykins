using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollector : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Obstacle" || target.tag == "Coin") {
            target.gameObject.SetActive(false);
        }
    }
}
