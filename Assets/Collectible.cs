using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Sprite collectibleSprite; // The sprite of the collectible
    private CollectibleManager collectibleManager; // Reference to the CollectibleManager

    private void Start()
    {
        collectibleManager = FindObjectOfType<CollectibleManager>();
        if (collectibleManager == null)
        {
            Debug.LogError("CollectibleManager not found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the CollectibleManager reference is valid
            if (collectibleManager != null)
            {
                // Call the AddCollectedItem method to add this collectible to the list
                collectibleManager.AddCollectedItem(gameObject);
            }
            else
            {
                Debug.LogWarning("CollectibleManager reference is null!");
            }

            // Hide or deactivate the collectible object
            gameObject.SetActive(false);
        }
    }
}












