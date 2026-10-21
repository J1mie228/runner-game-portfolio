using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwipeInput : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    
    private Vector2 _swipeStartPosition;
    
    private int _swipeDirection; //0 - left, 1 - right
    
    public static event Action<int> OnHorizontalSwipe;
    public static event Action OnSwipeUp;
    
    public int SwipeDirection => _swipeDirection;

    private void Update()
    {
        ReadSwipeInput();
    }
    
    private void ReadSwipeInput()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                _swipeStartPosition = touch.position;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                HandleSwipe(touch.position);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _swipeStartPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                HandleSwipe(Input.mousePosition);
            }
        }
    }

    private void HandleSwipe(Vector2 swipeEndPosition)
    {
        Vector2 swipeDelta = swipeEndPosition - _swipeStartPosition;

        float absX = Mathf.Abs(swipeDelta.x);
        float absY = Mathf.Abs(swipeDelta.y);

        if (Mathf.Max(absX, absY) < _playerConfig.SwipeThreshold) 
        {
            return;
        }

        if (Mathf.Abs(swipeDelta.x) < Mathf.Abs(swipeDelta.y))
        {
            if(swipeDelta.y > 0)
            {
                OnSwipeUp?.Invoke();
            }

            return;
        }

        if(swipeDelta.x > 0)
        {
            _swipeDirection = 1;
            OnHorizontalSwipe?.Invoke(SwipeDirection);
        }
        else if(swipeDelta.x < 0)
        {
            _swipeDirection = 0;
            OnHorizontalSwipe?.Invoke(SwipeDirection);
        }
    }
}
