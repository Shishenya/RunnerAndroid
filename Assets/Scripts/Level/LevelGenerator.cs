using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    private List<GameObject> activePlatfoms = new List<GameObject>();
    private float _spawnPos = 0f;
    private float _platformLength = 100f;

    [SerializeField] private Transform player;
    private int _startAmountPlatform = 4;

    private void Start()
    {

        for (int i = 0; i < _startAmountPlatform; i++)
        {
            SpawnPlatform(Random.Range(0, platformPrefabs.Length));
        }
    }

    private void Update()
    {
        //if (player.position.z - (_platformLength / 2 + 10f) > _spawnPos - (_startAmountPlatform * _platformLength))
        //{
        //    SpawnPlatform(Random.Range(0, platformPrefabs.Length));
        //    // DeletePlatform();
        //    PlayerController.Instance.IncrementSpeed();
        //}

        if (player.position.z > activePlatfoms[0].transform.position.z + _platformLength + 10f)
        {
            SpawnPlatform(Random.Range(0, platformPrefabs.Length));
            DeletePlatform();
            PlayerController.Instance.IncrementSpeed();
        }
    }

    /// <summary>
    /// Спавн платформы
    /// </summary>
    private void SpawnPlatform(int index)
    {
        GameObject platform = Instantiate(platformPrefabs[index], transform.forward * _spawnPos, transform.rotation);
        activePlatfoms.Add(platform);
        _spawnPos += _platformLength;
    }

    /// <summary>
    /// Удаление ненужных платформ
    /// </summary>
    private void DeletePlatform()
    {
        Destroy(activePlatfoms[0]);
        activePlatfoms.RemoveAt(0);
    }

}
