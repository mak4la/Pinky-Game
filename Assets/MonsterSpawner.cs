using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private float spawnRange = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsterRoutine());
    }

    IEnumerator SpawnMonsterRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            SpawnMonsterRandom();
        }
    }

    void SpawnMonsterRandom()
    {
        float randomX = Random.Range(-7.63f, 8.25f); // Generate a random X coordinate
        float randomY = Random.Range(7.21f, 7.23f); // Generate a random Y coordinate
        Vector3 spawnPosition = new Vector3(randomX,randomY, 0); // Create a spawn position vector
        GameObject newMonster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
        Destroy(newMonster, 3);
    }
}

