using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodControl : MonoBehaviour {

    public static string[] food = { "apple_ok", "burger_ok", "meat_ok"};

    private static float[] y = { 26f, 14.5f, -2.5f, -14.3f, -27.7f };
    private static float[] x = { -15.48f, -0.4332199f};

    public static void FoodGenerate_kill_me_please()
    {
        for (int i = 0; i < food.Length; i++)
        {
            GameObject go = GameObject.Find("Fridge/otkryt_pustoy/food/" + food[i]);
            if (go != null)
            {
                go.SetActive(value: true);
                int should = Random.Range(0, 2);
                if (should == 1)
                {
                    go.SetActive(true);
                    Vector3 temp = go.transform.position;
                    go.transform.position = new Vector3(Random.Range(x[0], x[1]), y[Random.Range(0, y.Length - 1)], temp.z);
                }
                else
                    go.SetActive(false);
            }
            else
            {
                Debug.Log("but why?");
            }
        }
    }
}
