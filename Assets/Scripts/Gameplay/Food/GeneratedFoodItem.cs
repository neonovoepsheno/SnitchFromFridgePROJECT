using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedFoodItem {
    public GameObject go;
    public int startOpenFridgeCounter = 0;

    public GeneratedFoodItem(GameObject go, int currentOpenFridgeCounter)
    {
        this.go = go;
        this.startOpenFridgeCounter = currentOpenFridgeCounter;
    }

    public int GetExistance(int currentOpenFridgeCounter)
    {
        return currentOpenFridgeCounter - startOpenFridgeCounter;
    }
}
