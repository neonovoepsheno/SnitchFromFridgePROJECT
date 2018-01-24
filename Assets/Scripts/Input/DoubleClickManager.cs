using UnityEngine;

public class DoubleClickManager : MonoBehaviour
{
    public static bool DoubleClick = false;
    bool one_click = false;
    bool timer_running;
    float timer_for_double_click;
    float delay = 0.4f;

    private void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            if (!one_click)
            {
                timer_for_double_click = GameProgress.GAME_TIME;
                one_click = true;
                DoubleClick = false;
            }
            else
            {
                one_click = false;
                Debug.Log("DoubleClick");
                DoubleClick = true;
            }
        }
        if (one_click)
        {
            if ((GameProgress.GAME_TIME - timer_for_double_click) > delay)
            {
                one_click = false;
                DoubleClick = false;
            }
        }
    }
}
