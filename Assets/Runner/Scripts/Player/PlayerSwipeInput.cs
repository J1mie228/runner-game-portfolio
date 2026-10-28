using System;
using UnityEngine;

public class PlayerSwipeInput : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    
    [SerializeField] private SwipeDirection _swipeDirection = SwipeDirection.None;

    private Vector2 _swipeStartPosition;
    
    public SwipeDirection LastSwipe => _swipeDirection;
    
    public static event Action<SwipeDirection> OnHorizontalSwipe;
    
    public static event Action OnSwipeUp;

    private void Update()
    {
        ReadSwipeInput();
    }

    private void ReadSwipeInput()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                _swipeStartPosition = touch.position;
            else if (touch.phase == TouchPhase.Ended)
                HandleSwipe(touch.position);

            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            _swipeStartPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            HandleSwipe(Input.mousePosition);
        }
    }

    private void HandleSwipe(Vector2 endPosition)
    {
        var delta = endPosition - _swipeStartPosition;

        if (!IsLongEnough(delta))
        {
            _swipeDirection = SwipeDirection.None;
            return;
        }

        _swipeDirection = Classify(delta);
        Dispatch(_swipeDirection);
    }

    private bool IsLongEnough(Vector2 delta)
    {
        float absX = Mathf.Abs(delta.x);
        float absY = Mathf.Abs(delta.y);
        return Mathf.Max(absX, absY) >= _playerConfig.SwipeThreshold;
    }

    private static SwipeDirection Classify(Vector2 delta)
    {
        // Вертикальный свайп
        if (Mathf.Abs(delta.x) < Mathf.Abs(delta.y))
            return delta.y > 0 ? SwipeDirection.Up : SwipeDirection.None;

        // Горизонтальный свайп
        return delta.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
    }

    private static void Dispatch(SwipeDirection direction)
    {
        switch (direction)
        {
            case SwipeDirection.Left:
            case SwipeDirection.Right:
                OnHorizontalSwipe?.Invoke(direction);
                break;

            case SwipeDirection.Up:
                OnSwipeUp?.Invoke();
                break;
        }
    }
}
