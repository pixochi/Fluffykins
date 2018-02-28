using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

    public static GamePlayController instance;
    private int score = 0;

    [SerializeField]
    private Text scoreText;

    void Awake () {
        makeInstance();
    }

    private void makeInstance() {
        if (instance == null) {
            instance = this;
        }
    }

    public void SetScore(int points) {
        score = points;
        scoreText.text = "" + score;
    }

    public int GetScore() {
        return score;
    }
}
