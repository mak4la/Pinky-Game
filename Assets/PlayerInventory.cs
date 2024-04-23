using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject inventoryUI; // Reference to the inventory UI panel
    public List<Sprite> collectedItems = new List<Sprite>(); // List to store collected item sprites
    public InventoryUI inventoryUIScript; // Reference to the InventoryUI script

    // Add item to the inventory
    public void AddItem(Sprite itemSprite)
    {
        collectedItems.Add(itemSprite);
        UpdateInventoryUI(); // Call method to update inventory UI
    }

    // Update the inventory UI with collected items
    private void UpdateInventoryUI()
    {
        if (inventoryUIScript != null)
        {
            // Pass the array of collected item sprites to the InventoryUI script
            inventoryUIScript.UpdateInventory(collectedItems.ToArray());
        }
        else
        {
            Debug.LogWarning("InventoryUI script reference is missing!");
        }
    }

    // Open or close the inventory
    public void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}




