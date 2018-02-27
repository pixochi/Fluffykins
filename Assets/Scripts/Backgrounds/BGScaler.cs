using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    void Start()
    {
        float aspectRatio = Screen.width / Screen.height;
        float height = Camera.main.orthographicSize * 2f;
        float width = height * aspectRatio * 2f;

        if (gameObject.name == "Background") {
            transform.localScale = new Vector3(width, height, 0);
        }
        else if (gameObject.name == "Ground") {
            transform.localScale = new Vector3(width + 3f, 5, 0);
        }
    }
}
