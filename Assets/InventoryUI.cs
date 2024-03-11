using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Image[] inventorySlots; // Array of UI images representing inventory slots

    // This method updates the inventory UI based on the collected items
    public void UpdateInventory(Sprite[] collectedItems)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < collectedItems.Length)
            {
                // Set the sprite of the UI image in the inventory slot to represent the collected item
                inventorySlots[i].sprite = collectedItems[i];
                inventorySlots[i].gameObject.SetActive(true); // Make sure the inventory slot is active
            }
            else
            {
                inventorySlots[i].gameObject.SetActive(false); // Deactivate unused inventory slots
            }
        }
    }
}


