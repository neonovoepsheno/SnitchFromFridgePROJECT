using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeController : MonoBehaviour
{

    public GameObject fridgeOpen;
    public GameObject fridgeClose;
    public GameObject fridgeOpen_bkg;
    public GameObject fridgeClose_bkg;

    public float delta = .30f;
    public static float DELTA;
    public static float timeOpenFridge;

    // Use this for initialization
    void Start()
    {
        delta = 1.5f;
        DELTA = delta;
        fridgeClose.SetActive(true);
        fridgeOpen.SetActive(false);
        fridgeClose_bkg.SetActive(true);
        fridgeOpen_bkg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        delta = DELTA;
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
                if (SwipeManager.SWIPE_ENABLE)
                {
                    fridgeClose.SetActive(false);
                    fridgeOpen.SetActive(true);
                    fridgeClose_bkg.SetActive(false);
                    fridgeOpen_bkg.SetActive(true);

                    FoodControl.FoodGenerate();
                    timeOpenFridge = GameProgress.GAME_TIME;
                    GameProgress.FRIDGE_OPEN_COUNTER++;
                }
            }
            else if (SwipeManager.IsSwiping(SwipeDirection.Left))
            {
                if (SwipeManager.SWIPE_ENABLE)
                {
                    FoodControl.ClearGeneratedFood();

                    fridgeClose.SetActive(true);
                    fridgeOpen.SetActive(false);
                    fridgeClose_bkg.SetActive(true);
                    fridgeOpen_bkg.SetActive(false);
                }
            }
        }
    }
}
