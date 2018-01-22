using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaturationBarController : MonoBehaviour {

    public Slider saturationBar;
    public Text score;
    public static float currValue;

    [SerializeField]
    private int TOTAL_TIME = 6;
    [SerializeField]
    private float DELTA = 0.0005f;
    [SerializeField]
    private float COEF_MAX = 0.035f;

    private float maxValue = 100f;
    private float coef_help = 0f;

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

        if (coef_help < COEF_MAX)
        {
          coef_help += DELTA;
        }
    }
}
