using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour {

    public static SceneFader instance;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject canvas;

    void Awake () {
        makeSingleton();

    }

    public void FadeIn(string levelName) {
        StartCoroutine(FadeInAnim(levelName));
        
    }

    public void FadeOut() {
        StartCoroutine(FadeOutAnim());
    }

    IEnumerator FadeInAnim(string sceneName) {
        canvas.SetActive(true);
        anim.Play("FadeIn");
        yield return StartCoroutine(WaitForRealSeconds(.7f));
        Application.LoadLevel(sceneName);
        FadeOut();
    }

    IEnumerator FadeOutAnim() {
        anim.Play("FadeOut");
        yield return StartCoroutine(WaitForRealSeconds(1f));
        canvas.SetActive(false);
    }

    private void makeSingleton() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public static IEnumerator WaitForRealSeconds(float time)
    {
        float start = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup < (start + time)) {
            yield return null;
        }
    }
}
