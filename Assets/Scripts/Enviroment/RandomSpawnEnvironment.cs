using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject[] _environnments;
    [Range(0, 100)]
    [SerializeField] private int _chancseSpawn;

    private void Start()
    {
        for (int i = 0; i < _environnments.Length; i++)
        {
            int random = Random.Range(0, 100);
            if (random>_chancseSpawn)
            {
                _environnments[i].SetActive(false);
            }
        }
    }
}
