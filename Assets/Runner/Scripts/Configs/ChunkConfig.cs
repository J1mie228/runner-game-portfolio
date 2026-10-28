using UnityEngine;

[CreateAssetMenu(fileName = "ChunkConfig", menuName = "Configs/ChunkConfig")]
public class ChunkConfig : ScriptableObject
{
    [SerializeField] private float _initialMoveSpeed = 8f;
    [SerializeField] private float _maxMoveSpeed = 30f;
    [SerializeField] private float _speedIncreasePerSecond = 0.5f;
    [SerializeField] private float _recycleDistance = 40f;

    public float InitialMoveSpeed => _initialMoveSpeed;
    public float MaxMoveSpeed => _maxMoveSpeed;
    public float SpeedIncreasePerSecond => _speedIncreasePerSecond;
    public float RecycleDistance => _recycleDistance;
}
