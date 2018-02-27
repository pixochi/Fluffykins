using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour {

    public float speed = .1f;
    private Material material;
    private Vector2 materialOffset;

    void Start() {
        material = GetComponent<Renderer>().material;
        materialOffset = material.GetTextureOffset("_MainTex");
    }

    void Update() {
        materialOffset.x += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", materialOffset);
    }
}
