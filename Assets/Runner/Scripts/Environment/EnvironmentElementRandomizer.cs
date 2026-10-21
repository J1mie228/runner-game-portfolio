using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnvironmentElementRandomizer : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float _spawnChance = 0.9f;
    
    private MeshRenderer _meshRenderer;

    private void OnEnable()
    {
        ChunkMover.OnExitedBoundary += RandomizeEnvironment;
    }

    private void OnDisable()
    {
        ChunkMover.OnExitedBoundary -= RandomizeEnvironment;
    }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        RandomizeEnvironment();
    }

    public void RandomizeEnvironment()
    {
        _meshRenderer.enabled = Random.value < _spawnChance;
    }
}
