using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCaseController : MonoBehaviour {

    public GameObject losePanel;
    public Text currentScore;
    public Text bestScore;

    // Use this for initialization
    void Start () {
        losePanel.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if (!GameProgress.IS_GAME_ACTIVE)
      {
            losePanel.SetActive(true);
            currentScore.text = "Current score: " + string.Format("{0:N2}", GameProgress.CURRENT_SCORE);
            //currentScore.text = "Current score: " + string.Format("{0:N2}", GameProgress.BEST_SCORE);
            //cuz for us ur alwayse the best
            bestScore.text = "Best score: " + string.Format("{0:N2}", GameProgress.BEST_SCORE);
        }
	}

    public void OnRetry()
    {
        Application.LoadLevel("main");
    }
}
