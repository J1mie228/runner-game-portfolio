using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static event Action OnPlayerHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerLineMover _))
            OnPlayerHit?.Invoke();
    }
}
