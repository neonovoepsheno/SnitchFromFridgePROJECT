using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public static bool IS_GAME_ACTIVE;

    public static float BEST_SCORE;
    public static float CURRENT_SCORE;

    public static float GAME_TIME;

    void Start()
    {
        BEST_SCORE = PlayerPrefs.GetFloat("BEST_SCORE", 0);
        CURRENT_SCORE = 0;

        GAME_TIME = 0;
    }

    void Update()
    {
        if (CURRENT_SCORE > BEST_SCORE)
        {
            BEST_SCORE = CURRENT_SCORE;
            PlayerPrefs.SetFloat("BEST_SCORE", BEST_SCORE);
        }

        GAME_TIME += Time.deltaTime;

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
