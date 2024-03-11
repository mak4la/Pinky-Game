using UnityEngine;
using UnityEngine.UI;

public class CollectibleLoader : MonoBehaviour
{
    public Image[] inventorySlots; // Array of UI images representing inventory slots

    // Method to load a collectible sprite into an empty slot
    public void LoadCollectible(Sprite collectibleSprite)
    {
        // Find the first empty slot in the inventory
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].sprite == null)
            {
                // Set the sprite of the empty slot to the collectible sprite
                inventorySlots[i].sprite = collectibleSprite;
                inventorySlots[i].color = Color.white;

                // Debug statement to indicate successful loading
                Debug.Log("Collectible loaded into slot " + i);
                Debug.Log("Collectible sprite: " + collectibleSprite);
                Debug.Log("Inventory slot image component: " + inventorySlots[i]);

                return; // Exit the loop after loading the sprite
            }
        }

        // Debug statement if no empty slots are found
        Debug.LogWarning("No empty slots available for loading collectible!");
    }
}



