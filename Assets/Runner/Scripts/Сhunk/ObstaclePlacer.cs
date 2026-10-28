using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePlacer : MonoBehaviour
{
    [SerializeField] private float[] _laneXPositions = { -2f, 0f, 2f };
    [SerializeField] private float _minZ = 5f;
    [SerializeField] private float _maxZ = 25f;
    [SerializeField] private Obstacle[] _obstaclePrefabs;
    [SerializeField] private int _minObstacles = 1;
    [SerializeField] private int _maxObstacles = 2;

    private readonly List<Obstacle> _spawnedObstacles = new List<Obstacle>();

    public void Randomize()
    {
        ClearObstacles();

        if (_obstaclePrefabs == null || _obstaclePrefabs.Length == 0)
            return;

        if (_laneXPositions == null || _laneXPositions.Length == 0)
            return;

        int maxAllowed = _laneXPositions.Length - 1;
        int obstaclesToSpawn = Mathf.Min(Random.Range(_minObstacles, _maxObstacles + 1), maxAllowed);

        // Выбираем уникальные линии, чтобы не поставить два препятствия в одну
        var availableLanes = new List<float>(_laneXPositions);

        for (int i = 0; i < obstaclesToSpawn; i++)
        {
            int laneIndex = Random.Range(0, availableLanes.Count);
            float laneX = availableLanes[laneIndex];
            availableLanes.RemoveAt(laneIndex);

            float z = Random.Range(_minZ, _maxZ);

            var obstaclePrefab = _obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)];
            var obstacleInstance = Instantiate(obstaclePrefab, transform);

            obstacleInstance.transform.localPosition = new Vector3(laneX, 0f, z);

            _spawnedObstacles.Add(obstacleInstance);
        }
    }

    private void ClearObstacles()
    {
        foreach (var obstacle in _spawnedObstacles)
        {
            if (obstacle != null)
                Destroy(obstacle.gameObject);
        }

        _spawnedObstacles.Clear();
    }

    private void OnValidate()
    {
        if (_maxObstacles < _minObstacles)
            _maxObstacles = _minObstacles;

        if (_minObstacles < 0)
            _minObstacles = 0;

        if (_maxZ < _minZ)
            _maxZ = _minZ;
    }
}
