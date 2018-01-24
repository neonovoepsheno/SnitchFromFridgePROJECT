using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour {

    private static string jsonProductsPath = "/Scripts/Json/Products.json";
    public static ProductCollection productCollection;

    private void Awake()
    {
        DataController.LoadProductsData(Application.dataPath + jsonProductsPath);
    }

    public static void LoadProductsData(string path)
    {
        using (StreamReader stream = new StreamReader(path))
        {
            string jsonText = stream.ReadToEnd();
            productCollection = JsonUtility.FromJson<ProductCollection>(jsonText);
            //Debug.Log(productCollection.products[0].ProductType);
        }
    }

    public static Product GetProductByID(string p_id)
    {
        for (int i = 0; i < productCollection.products.Length; i++)
        {
            if (p_id.Equals(productCollection.products[i].ProductID) || p_id.Equals(productCollection.products[i].ProductID + "(Clone)"))
            {
                return productCollection.products[i];
            }
        }
        return null;
    }
}
