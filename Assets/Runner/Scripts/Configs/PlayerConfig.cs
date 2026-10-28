using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] float[] _laneXPositions = {-3f, 0f, 3f};
    [SerializeField] private float _laneChangeSpeed = 12f;
    
    [SerializeField] private float _jumpHeight = 1.5f;
    
    [SerializeField] private float _gravity = -20f;
    
    [SerializeField] private float _swipeThreshold = 30f;
    
    public float[]LaneXPositions => _laneXPositions;
    public float LaneChangeSpeed => _laneChangeSpeed;
    public float JumpHeight => _jumpHeight;
    public float Gravity => _gravity;
    public float SwipeThreshold => _swipeThreshold;
}
