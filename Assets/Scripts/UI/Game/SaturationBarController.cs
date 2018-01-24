using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaturationBarController : MonoBehaviour
{

    public Slider saturationBar;
    public Text score;
    public static float currValue;
    public static float maxValue;
    
    private float TOTAL_TIME;
    private float DELTA;
    private float _delta_start;
    private float COEF_MAX;
    private float _coef_max_start;
    private float coef_help;

    // Use this for initialization
    void Start()
    {
        coef_help = 0;
        COEF_MAX = 0.035f;
        _coef_max_start = COEF_MAX;
        DELTA = 0.0001f;
        _delta_start = DELTA;
        maxValue = 100f;
        TOTAL_TIME = 6f;

        score.gameObject.SetActive(true);
        currValue = maxValue;
        saturationBar.value = currValue;
        GameProgress.IS_GAME_ACTIVE = true;
    }

    // Update is called once per frame
    void Update()
    {
        TOTAL_TIME = (6f * maxValue) / 100f;
        COEF_MAX = (_coef_max_start * maxValue) / 100f;
        DELTA = (_delta_start * maxValue) / 100f;
        if (GameProgress.IS_GAME_ACTIVE)
        {
            GameProgress.CURRENT_SCORE += Time.deltaTime;
            score.text = "Score " + string.Format("{0:N2}", GameProgress.CURRENT_SCORE);
            if (currValue > 0)
            {
                BarUpdate();
            }
            else
            {
                GameProgress.IS_GAME_ACTIVE = false;
                score.gameObject.SetActive(false);
            }
        }
        saturationBar.maxValue = maxValue;
    }

    private void BarUpdate()
    {
        currValue -= ((Time.deltaTime + coef_help) * maxValue) / TOTAL_TIME;
        saturationBar.value = currValue;

        if (coef_help < COEF_MAX)
        {
            coef_help += DELTA;
        }
    }
}
