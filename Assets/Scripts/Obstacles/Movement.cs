using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = -5f;
    private Rigidbody2D obstacle;

	void Awake () {
        obstacle = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        obstacle.velocity = new Vector3(speed, 0);
	}
}
