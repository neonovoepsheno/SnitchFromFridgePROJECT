﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeController : MonoBehaviour {

    public GameObject fridgeOpen;
    public GameObject fridgeClose;
    public GameObject fridgeOpen_bkg;
    public GameObject fridgeClose_bkg;

    public float delta = .30f;
    public static float timeOpenFridge;
    [SerializeField]
    private bool swipe_enable = true;
    public static bool SWIPE_ENABLE;

    // Use this for initialization
    void Start () {
        fridgeClose.SetActive(true);
        fridgeOpen.SetActive(false);
        fridgeClose_bkg.SetActive(true);
        fridgeOpen_bkg.SetActive(false);

        SWIPE_ENABLE = swipe_enable;
    }

	// Update is called once per frame
	void Update () {
        if (!GameProgress.IS_GAME_ACTIVE || GameProgress.GAME_TIME - timeOpenFridge > delta)
        {
            fridgeClose.SetActive(true);
            fridgeOpen.SetActive(false);
            fridgeClose_bkg.SetActive(true);
            fridgeOpen_bkg.SetActive(false);

            FoodControl.ClearGeneratedFood();
        }
        if (GameProgress.IS_GAME_ACTIVE)
        {
            if (SwipeManager.IsSwiping(SwipeDirection.Right) && !fridgeOpen.activeSelf)
            {
              if (SWIPE_ENABLE)
              {
                fridgeClose.SetActive(false);
                fridgeOpen.SetActive(true);
                fridgeClose_bkg.SetActive(false);
                fridgeOpen_bkg.SetActive(true);

                FoodControl.FoodGenerate();
                timeOpenFridge = GameProgress.GAME_TIME;
              }
            }
            else if (SwipeManager.IsSwiping(SwipeDirection.Left))
            {
              if (SWIPE_ENABLE)
              {
                fridgeClose.SetActive(true);
                fridgeOpen.SetActive(false);
                fridgeClose_bkg.SetActive(true);
                fridgeOpen_bkg.SetActive(false);

                FoodControl.ClearGeneratedFood();
              }
            }
        }
    }
}
