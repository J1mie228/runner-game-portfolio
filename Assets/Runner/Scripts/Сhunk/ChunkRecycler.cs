using System.Collections.Generic;
using UnityEngine;

public class ChunkRecycler : MonoBehaviour
{
    [SerializeField] private List<Transform> _chunks = new List<Transform>();
    [SerializeField] private TrackConfig _trackConfig;

    private void Update()
    {
        if (_chunks.Count < 2) return;
        
        while (_chunks.Count > 1 && _chunks[0].position.z <= _trackConfig.RecycleZ)
        {
            RecycleFirstChunk();
        }
    }

    private void RecycleFirstChunk()
    {
        Transform chunkToRecycle = _chunks[0];
        Transform lastChunk = _chunks[_chunks.Count - 1];
        
        float newZ = lastChunk.position.z + _trackConfig.ChunkLength;
        Vector3 pos = chunkToRecycle.position;
        chunkToRecycle.position = new Vector3(pos.x, pos.y, newZ);
        
        _chunks.RemoveAt(0);
        _chunks.Add(chunkToRecycle);
    }
}
