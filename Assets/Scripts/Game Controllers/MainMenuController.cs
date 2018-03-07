using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    public static MainMenuController instance;

    void Awake()
    {
        makeInstance();
    }

    void makeInstance()
    {
        if (instance == null) {
            instance = this;
        }
    }

    public void PlayGame()
    {
        SceneFader.instance.FadeIn("GamePlay");
    }
}
