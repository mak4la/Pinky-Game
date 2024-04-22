using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject coinPrefab;
    public int numberOfCoins = 10;
    public float minX = -25f;
    public float maxX = 40f;
    public float minY = -12f;
    public float maxY = 16f;
    public float minSpacing = 5f; // Minimum distance between coins

    void Start()
    {
        GenerateCoins();
    }

    void GenerateCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            // Generate random position within the specified range
            Vector2 randomPosition;
            bool validPosition = false;

            // Keep generating random positions until a valid one is found
            do
            {
                randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                validPosition = IsPositionValid(randomPosition);
            } while (!validPosition);

            // Instantiate the coin prefab at the random position
            Instantiate(coinPrefab, randomPosition, Quaternion.identity);
        }
    }

    bool IsPositionValid(Vector2 position)
    {
        // Check if the position is too close to any cloud platform
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, minSpacing);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("CloudPlatform"))
            {
                return false;
            }
        }
        return true;
    }
}

