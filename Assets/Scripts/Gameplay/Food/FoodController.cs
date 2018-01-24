using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private float time_of_action = 0;
    private float start_time = 0;
    private float coef = 1;
    private float coef_for_rot = 0.43f;
    private int changePositionCounter = 0;

    private void Start()
    {
    }

    private void Update()
    {
        if (start_time > time_of_action)
        {
            coef = 1;
        }
        start_time += Time.deltaTime;
    }

    public void OnMouseDown()
    {
        this.gameObject.SetActive(false);
        string name = this.gameObject.name;
        if (name == "apple(Clone)")
        {
            SaturationBarController.currValue += 2 / coef;
            SaturationBarController.maxValue += 2 / coef;
        }
        else if (name == "apple_rot(Clone)")
        {
            start_time = 0;
            time_of_action += 1.2f;
            coef = 2;
            SaturationBarController.currValue += 2 * coef_for_rot;
            SaturationBarController.maxValue += 2 * coef_for_rot;
        }
        else if (name == "burger(Clone)")
        {
            SaturationBarController.currValue += 35 / coef;
            SaturationBarController.maxValue += 35 / coef;
        }
        else if (name == "burger_rot(Clone)")
        {
            start_time = 0;
            time_of_action += 3.5f;
            coef = 2;
            SaturationBarController.currValue += 35 * coef_for_rot;
            SaturationBarController.maxValue += 35 * coef_for_rot;
        }
        else if (name == "beefsteak(Clone)")
        {
            SaturationBarController.currValue += 20 / coef;
            SaturationBarController.maxValue += 20 / coef;
        }
        else if (name == "meat_rot(Clone)")
        {
            start_time = 0;
            time_of_action += 2.7f;
            coef = 2;
            SaturationBarController.currValue += 20 * coef_for_rot;
            SaturationBarController.maxValue += 20 * coef_for_rot;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (changePositionCounter < 5)
        {
            changePositionCounter++;
            FoodControl.ChangeObjectPosition(this.gameObject);
        }
    }
}
