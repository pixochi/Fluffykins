using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

    public static GamePlayController instance;
    private int score = 0;
    private int distance = 0;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text distanceText;
    public bool isPlayerRunning;

    void Awake () {
        makeInstance();
    }

    void Start() {
        StartCoroutine(CountDistance());
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

    private IEnumerator CountDistance() {
        yield return new WaitForSeconds(.7f);
        if (isPlayerRunning) {
            distance++;
            distanceText.text = distance + " M";
        }
        StartCoroutine(CountDistance());
    }
}
