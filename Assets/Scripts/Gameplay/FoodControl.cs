using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//добавь rigidbody, чтобы они падали

public class FoodControl : MonoBehaviour
{

    public GameObject[] food;

    private static List<GeneratedFoodItem> generatedFood = new List<GeneratedFoodItem>();
    private static float[] y = { 6f, 3.65f, -1.96f, 0.5f, -4.66f };
    private static float[] x = { -3f, 0f };
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
                    for (int iter = 0; iter < Random.Range(1, 2); iter++)
                    {
                        GameObject tempFood = Instantiate(foodPrefab[i]);
                        tempFood.AddComponent<FoodController>();

                        generatedFood.Add(new GeneratedFoodItem(tempFood, GameProgress.FRIDGE_OPEN_COUNTER));
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

    public static void ChangeObjectPosition(GameObject foodObject)
    {
        foodObject.transform.position = new Vector3(Random.Range(x[0], x[1]), y[Random.Range(0, y.Length - 1)], 6f);
    }

    public static void ClearGeneratedFood()
    {
        for (int i = 0; i < generatedFood.Count; i++)
        {
            if (generatedFood[i].go != null)
            {
                Product product = DataController.GetProductByID(generatedFood[i].go.name);
                if (!generatedFood[i].go.activeSelf)
                {
                    Destroy(generatedFood[i].go);
                    generatedFood.Remove(generatedFood[i]);
                }
                else if (generatedFood[i].GetExistance(GameProgress.FRIDGE_OPEN_COUNTER) % product.RottenAppeare == 0)
                {
                    generatedFood[i].go.transform.GetChild(0).gameObject.SetActive(false);
                    generatedFood[i].go.transform.GetChild(1).gameObject.SetActive(true);
                    product.State = "rot";
                }
            }
        }
    }
}
