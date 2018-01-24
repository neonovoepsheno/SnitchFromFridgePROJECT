using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFridgeState : MonoBehaviour
{
    public GameObject fridgeOpen;
    public GameObject fridgeClose;
    public GameObject fridgeOpen_bkg;
    public GameObject fridgeClose_bkg;

    public void OnMouseDown()
    {
        if (!SwipeManager.SWIPE_ENABLE)
        {
            if (!fridgeClose.activeSelf)
            {
                FoodControl.ClearGeneratedFood();
            }
            fridgeClose.SetActive(!fridgeClose.activeSelf);
            fridgeOpen.SetActive(!fridgeOpen.activeSelf);
            fridgeClose_bkg.SetActive(!fridgeClose_bkg.activeSelf);
            fridgeOpen_bkg.SetActive(!fridgeOpen_bkg.activeSelf);
            if (!fridgeClose.activeSelf)
            {
                FoodControl.FoodGenerate();
                FridgeController.timeOpenFridge = GameProgress.GAME_TIME;
            }
        }
    }
}
