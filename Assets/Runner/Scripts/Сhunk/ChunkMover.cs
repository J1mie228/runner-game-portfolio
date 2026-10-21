using System;
using UnityEngine;

public class ChunkMover : MonoBehaviour
{
    [SerializeField] private TrackConfig _trackConfig;
    
    private float _currentSpeed;
    
    private void Awake()
    {
        _currentSpeed = _trackConfig.BaseSpeed;
    }

    private void Update()
    {
        transform.position += Vector3.back * _currentSpeed * Time.deltaTime;

        if (_currentSpeed < _trackConfig.MaxSpeed)
        {
            _currentSpeed += _trackConfig.SpeedGrowthPerSecond * Time.deltaTime;
        }
    }
}
