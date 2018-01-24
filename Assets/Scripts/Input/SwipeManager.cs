﻿using UnityEngine;

public enum SwipeDirection { None = 0, Left = 1, Right = 2}

public class SwipeManager : MonoBehaviour
{

    private static SwipeDirection Direction { set; get; }
    public static bool IsSwipe { set; get; }

    [SerializeField]
    private bool swipe_enable = true;
    public static bool SWIPE_ENABLE;

    private Vector3 touchPosition;
    private float swipeResistanceX = 50f;

    private void Start()
    {
        SWIPE_ENABLE = swipe_enable;
        IsSwipe = true;
    }

    private void Update()
    {

        Direction = SwipeDirection.None;
        
        if (!DoubleClickManager.DoubleClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchPosition = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 deltaSwipe = touchPosition - Input.mousePosition;
                if (Mathf.Abs(deltaSwipe.x) > swipeResistanceX)
                {
                    Debug.Log("Swipe");
                    Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;
                }
            }
        }
    }


    public static bool IsSwiping(SwipeDirection dir)
    {
        return (Direction & dir) == dir;
    }
}