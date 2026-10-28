using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver;

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += HandlePlayerHit;
    }

    private void OnDisable()
    {
        Obstacle.OnPlayerHit -= HandlePlayerHit;
    }

    private void HandlePlayerHit()
    {
        if (_isGameOver)
            return;

        _isGameOver = true;
        Debug.Log("Game Over");

        Time.timeScale = 0f;
    }
}
