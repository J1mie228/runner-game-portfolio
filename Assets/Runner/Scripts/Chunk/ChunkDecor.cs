using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkDecor : MonoBehaviour
{
    [SerializeField] private GameObject[] _decorElements;
    [SerializeField, Range(0f, 1f)] private float _activeProbability = 0.6f;
    [SerializeField] private int _minimumActiveElements = 1;

    public void Randomize()
    {
        if (_decorElements == null || _decorElements.Length == 0)
            return;

        foreach (var decorElement in _decorElements)
        {
            if (decorElement != null)
                decorElement.SetActive(false);
        }

        int activeCount = 0;

        foreach (var decorElement in _decorElements)
        {
            if (decorElement == null)
                continue;

            if (Random.value < _activeProbability)
            {
                decorElement.SetActive(true);
                activeCount++;
            }
        }

        while (activeCount < _minimumActiveElements)
        {
            var randomElement = _decorElements[Random.Range(0, _decorElements.Length)];

            if (randomElement != null && randomElement.activeSelf == false)
            {
                randomElement.SetActive(true);
                activeCount++;
            }
            else
            {
                break;
            }
        }
    }
}
