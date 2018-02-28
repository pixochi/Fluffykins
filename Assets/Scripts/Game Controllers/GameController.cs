using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;
    private const string HIGH_SCORE = "HIGH_SCORE";

    private void makeSingleton()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    void Awake () {
        makeSingleton();
    }

    public void SetHighScore(int score) {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public int GetHighScore() {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }

}
