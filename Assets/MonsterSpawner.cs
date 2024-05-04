using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab; // Reference to the monster prefab
    public Transform[] spawnPoints; // Array of spawn points
    public float spawnInterval = 2f; // Time interval between spawns
    public float detectionRange = 5f; // Detection range of the monsters

    private Transform player; // Reference to the player's transform

    private void Start()
    {
        // Find the player object by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Start spawning monsters
        InvokeRepeating("SpawnMonster", 0f, spawnInterval);
    }

    private void SpawnMonster()
    {
        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the monster at the chosen spawn point
        GameObject monster = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);

        // Get the monster's AI script and set the player as the target
        FinalLevelAIPatrol aiChaser = monster.GetComponent<FinalLevelAIPatrol>();
        if (aiChaser != null)
        {
            aiChaser.player = player.gameObject;
        }
        else
        {
            Debug.LogWarning("Monster prefab does not have an FinalLevelAIPatrol component!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw detection range gizmos for all spawn points
        Gizmos.color = Color.red;
        foreach (Transform spawnPoint in spawnPoints)
        {
            Gizmos.DrawWireSphere(spawnPoint.position, detectionRange);
        }
    }
}
