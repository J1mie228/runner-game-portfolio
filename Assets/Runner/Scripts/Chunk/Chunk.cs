using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private float _chunkLength = 30f;
    [SerializeField] private ChunkDecor _decorRandomizer;
    [SerializeField] private ObstaclePlacer _obstaclePlacer;

    public float Length => _chunkLength;

    public void OnRecycled()
    {
        _decorRandomizer?.Randomize();
        _obstaclePlacer?.Randomize();
    }

    private void OnValidate()
    {
        _chunkLength = Mathf.Max(1f, _chunkLength);
    }
}
