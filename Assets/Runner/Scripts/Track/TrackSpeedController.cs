using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpeedController : MonoBehaviour
{
    [SerializeField] private TrackConfig _trackConfig;
    
    private float _currentChunkSpeed;
    
    private void Awake()
    {
        _currentChunkSpeed = _trackConfig.BaseSpeed;
    }

    private void Update()
    {
        _currentChunkSpeed = Mathf.Min(_currentChunkSpeed + _trackConfig.SpeedGrowthPerSecond * Time.deltaTime, _trackConfig.MaxSpeed);
    }
}
