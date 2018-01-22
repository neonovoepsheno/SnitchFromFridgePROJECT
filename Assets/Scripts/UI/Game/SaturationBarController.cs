using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaturationBarController : MonoBehaviour {

    public Slider saturationBar;
    public Text score;
    public float barSpeedMax = 30f;

    private float maxValue = 100;
    public static float currValue;
    private int TOTAL_TIME = 6;
    private float coef_help = 0;
    private float delta = 0.005f;

    private float barSpeedCurrent;

    // Use this for initialization
    void Start () {
        score.gameObject.SetActive(true);
        currValue = maxValue;
        saturationBar.value = currValue;
        GameProgress.IS_GAME_ACTIVE = true;
        coef_help = 0;
    }
	
	// Update is called once per frame
	void Update () {
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
	}

    private void BarUpdate()
    {        
        currValue -= ((Time.deltaTime + coef_help) * maxValue) / TOTAL_TIME;
        saturationBar.value = currValue;

        barSpeedCurrent = (maxValue - currValue) / GameProgress.GAME_TIME;
        //Debug.Log(barSpeedCurrent);

        if (barSpeedCurrent < barSpeedMax)
        {
            coef_help += delta;
        }
    }
}
