using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject cloudPrefab;
    public int numberOfClouds = 10;
    public float minX = -25f;
    public float maxX = 40f;
    public float minY = -12f;
    public float maxY = 16f;
    public float minSpacing = 2f; // Minimum distance between clouds

    void Start()
    {
        GenerateClouds();
    }

    void GenerateClouds()
    {
        for (int i = 0; i < numberOfClouds; i++)
        {
            // Generate random position within the specified range
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            // Check if the new cloud position violates the minimum spacing rule
            bool validPosition = true;
            foreach (var cloud in GameObject.FindGameObjectsWithTag("CloudPlatform"))
            {
                if (Vector2.Distance(cloud.transform.position, new Vector2(randomX, randomY)) < minSpacing)
                {
                    validPosition = false;
                    break;
                }
            }

            // Instantiate the cloud prefab at the random position if it meets the rules
            if (validPosition)
            {
                Instantiate(cloudPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);
            }
        }
    }
}



