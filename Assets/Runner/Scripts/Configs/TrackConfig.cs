using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrackConfig", menuName = "Configs/TrackConfig")]
public class TrackConfig : ScriptableObject
{
    [SerializeField] private float _baseSpeed = 5f;
    [SerializeField] private float _maxSpeed = 30f;
    
    [SerializeField] private float _speedGrowthPerSecond = 0.5f;
    
    [SerializeField] private float _chunkLength = 60f;
    [SerializeField] private float _recycleZ = -30f;
    
    public float BaseSpeed => _baseSpeed;
    public float MaxSpeed => _maxSpeed;
    public float RecycleZ => _recycleZ;
    public float ChunkLength => _chunkLength;
    public float SpeedGrowthPerSecond => _speedGrowthPerSecond;
}
