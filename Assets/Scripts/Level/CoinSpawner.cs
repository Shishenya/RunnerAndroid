using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform[] _coinSpawnPoints;
    [SerializeField] private GameObject _parent;

    private void Start()
    {
        for (int i = 0; i < _coinSpawnPoints.Length; i++)
        {
            GameObject coin = Instantiate(_coinPrefab, _parent.transform);
            coin.transform.position = _coinSpawnPoints[i].position;
        }
    }
}
