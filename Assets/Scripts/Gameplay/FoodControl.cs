using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//добавь rigidbody, чтобы они падали

public class FoodControl : MonoBehaviour {

    //public static string[] food = { "apple_ok", "burger_ok", "meat_ok"};
    public GameObject[] food;

    private static List<GameObject> generatedFood = new List<GameObject>();
    private static float[] y = { 6f, 3.65f, -1.96f, 14.6f, -4.66f };
    private static float[] x = { -3f, 0f};
    private static GameObject[] foodPrefab;

    private void Start()
    {
      foodPrefab = food;
    }

    public static void FoodGenerate()
    {
        for (int i = 0; i < foodPrefab.Length; i++)
        {
            if (foodPrefab[i] != null)
            {
                if (Random.Range(0, 2) == 1)
                {
                  for (int iter = 0; iter < Random.Range(0, 5); iter++)
                  {
                    GameObject tempFood = Instantiate(foodPrefab[i]);
                    generatedFood.Add(tempFood);
                    tempFood.SetActive(true);
                    tempFood.transform.position = new Vector3(Random.Range(x[0], x[1]), y[Random.Range(0, y.Length - 1)], 6f);
                  }
                }
            }
            else
            {
                Debug.Log("but why?");
            }
        }
    }

    public static void ClearGeneratedFood()
    {
      for (int i = 0; i < generatedFood.Count; i++)
      {
        Destroy(generatedFood[i]);
      }
      generatedFood = new List<GameObject>();
    }
}
