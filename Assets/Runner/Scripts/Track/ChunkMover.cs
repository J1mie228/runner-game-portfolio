using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkMover : MonoBehaviour
{
    [SerializeField] private TrackConfig _trackConfig;
    
    private float _currentChunkSpeed;

    public static event Action<GameObject> OnExitedBoundary;

    private void Awake()
    {
        _currentChunkSpeed = _trackConfig.BaseSpeed;
    }

    private void Update()
    {
        _currentChunkSpeed = Mathf.Min(_currentChunkSpeed + _trackConfig.SpeedGrowthPerSecond * Time.deltaTime, _trackConfig.MaxSpeed);
        
        transform.position += Vector3.back * _currentChunkSpeed * Time.deltaTime;

        if (transform.position.z < _trackConfig.RecycleZ)
        {
            OnExitedBoundary?.Invoke(this.gameObject);
        }
    }
}
