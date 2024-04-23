using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Sprite collectibleSprite; // The sprite of the collectible
    public CollectibleManager collectibleManager; // Reference to the CollectibleManager

    private CollectibleLoader collectibleLoader; // Reference to the CollectibleLoader

    private void Start()
    {
        collectibleLoader = FindObjectOfType<CollectibleLoader>();
        if (collectibleLoader == null)
        {
            Debug.LogError("CollectibleLoader not found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the CollectibleLoader reference is valid
            if (collectibleLoader != null)
            {
                // Call the LoadCollectible method to load the collectible sprite into an empty slot
                collectibleLoader.LoadCollectible(collectibleSprite);
            }
            else
            {
                Debug.LogWarning("CollectibleLoader reference is null!");
            }
            collectibleManager.AddCollectedItem(gameObject);


            // Hide or deactivate the collectible object
            gameObject.SetActive(false);
        }
    }
}














