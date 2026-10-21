using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> _chunksInInspector;
    [SerializeField] private TrackConfig _trackConfig;
    
    private Queue<GameObject> _chunks;

    private void OnEnable()
    {
        ChunkMover.OnExitedBoundary += RecycleChunk;
    }

    private void OnDisable()
    {
        ChunkMover.OnExitedBoundary -= RecycleChunk;
    }
    
    private void Awake()
    {
        _chunks = new Queue<GameObject>(_chunksInInspector.Count);

        foreach (GameObject chunk in _chunksInInspector)
        {
            if (chunk != null)
            {
                _chunks.Enqueue(chunk);
            }
        }
    }

    private void RecycleChunk(GameObject _chunkToRecycle)
    {
        float newZ = _chunkToRecycle.transform.position.z + _trackConfig.ChunkLength;
        _chunkToRecycle.transform.position = new Vector3(0f, 0f, newZ);
        _chunks.Dequeue(_chunkToRecycle);
        _chunks.Enqueue(_chunkToRecycle);
    }
}
