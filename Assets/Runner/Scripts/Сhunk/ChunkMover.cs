using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkMover : MonoBehaviour
{
    [SerializeField] private ChunkConfig _chunkConfig;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private List<Chunk> _chunks;

    private float _elapsedTime;
    private float _currentMoveSpeed;

    private void Awake()
    {
        _elapsedTime = 0f;
        _currentMoveSpeed = _chunkConfig.InitialMoveSpeed;
    }

    private void Update()
    {
        UpdateCurrentSpeed();

        float recycleBoundaryZ = _playerTransform.position.z - _chunkConfig.RecycleDistance;

        foreach (var chunk in _chunks)
        {
            Vector3 movementStep = Vector3.back * (_currentMoveSpeed * Time.deltaTime);
            chunk.transform.position += movementStep;

            if (chunk.transform.position.z < recycleBoundaryZ)
                Recycle(chunk);
        }
    }

    private void UpdateCurrentSpeed()
    {
        _elapsedTime += Time.deltaTime;

        _currentMoveSpeed = _chunkConfig.InitialMoveSpeed
                            + _chunkConfig.SpeedIncreasePerSecond * _elapsedTime;

        if (_currentMoveSpeed > _chunkConfig.MaxMoveSpeed)
            _currentMoveSpeed = _chunkConfig.MaxMoveSpeed;
    }

    private void Recycle(Chunk recycledChunk)
    {
        float farthestChunkZ = float.MinValue;

        foreach (var chunk in _chunks)
        {
            if (chunk.transform.position.z > farthestChunkZ)
                farthestChunkZ = chunk.transform.position.z;
        }

        recycledChunk.transform.position = new Vector3(
            recycledChunk.transform.position.x,
            recycledChunk.transform.position.y,
            farthestChunkZ + recycledChunk.Length);

        recycledChunk.OnRecycled();
    }
}

