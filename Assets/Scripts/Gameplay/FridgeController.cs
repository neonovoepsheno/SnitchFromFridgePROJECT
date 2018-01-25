using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeController : MonoBehaviour
{

    public GameObject fridgeOpen;
    public GameObject fridgeClose;
    public GameObject fridgeOpen_bkg;
    public GameObject fridgeClose_bkg;

    [SerializeField]
    private float delta;
    public static float DELTA;

    public static float timeOpenFridge;

    // Use this for initialization
    void Start()
    {
        fridgeClose.SetActive(true);
        fridgeOpen.SetActive(false);
        fridgeClose_bkg.SetActive(true);
        fridgeOpen_bkg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameProgress.IS_GAME_ACTIVE)
        {
            CloseFridge();
        }
        else
        {
            if (SwipeManager.IsSwipingRight() && !fridgeOpen.activeSelf)
            {
                if (SwipeManager.SWIPE_ENABLE)
                {
                    OpenFridge();
                }
            }
            else if (SwipeManager.IsSwipingLeft())
            {
                if (SwipeManager.SWIPE_ENABLE)
                {
                    CloseFridge();
                }
            }
            if (GameProgress.GAME_TIME - timeOpenFridge > delta)
            {
                CloseFridge();
            }
        }
    }

    private void CloseFridge()
    {
        FoodControl.ClearGeneratedFood();

        fridgeClose.SetActive(true);
        fridgeOpen.SetActive(false);
        fridgeClose_bkg.SetActive(true);
        fridgeOpen_bkg.SetActive(false);
    }

    private void OpenFridge()
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
