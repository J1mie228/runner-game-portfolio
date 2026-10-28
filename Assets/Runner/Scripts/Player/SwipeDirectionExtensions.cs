public static class SwipeDirectionExtensions
{
    public static bool IsHorizontal(this SwipeDirection direction) =>
        direction is SwipeDirection.Left or SwipeDirection.Right;
    
    public static int ToLaneDelta(this SwipeDirection direction) => direction switch
    {
        SwipeDirection.Left  => -1,
        SwipeDirection.Right => +1,
        _                    => 0
    };
}
