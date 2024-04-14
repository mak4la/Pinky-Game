using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Sprite collectibleSprite; // The sprite of the collectible

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Access the CollectibleLoader component on the inventory panel
            CollectibleLoader collectibleLoader = FindObjectOfType<CollectibleLoader>();

            // Check if the CollectibleLoader component is found
            if (collectibleLoader != null)
            {
                // Call the LoadCollectible method to load the collectible sprite into an empty slot
                collectibleLoader.LoadCollectible(collectibleSprite);
            }
            else
            {
                Debug.LogWarning("CollectibleLoader not found!");
            }

            // Hide or deactivate the collectible object
            gameObject.SetActive(false);
        }
    }
}













