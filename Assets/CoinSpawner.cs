using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform[] spawnPoints; // Array of spawn points on the platforms

    void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Instantiate a coin at a random spawn point
            Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
