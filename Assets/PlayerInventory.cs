using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject inventoryUI; // Reference to the inventory UI panel
    public List<Sprite> collectedItems = new List<Sprite>(); // List to store collected item sprites

    // Add item to the inventory
    public void AddItem(Sprite itemSprite)
    {
        collectedItems.Add(itemSprite);
        UpdateInventoryUI(); // Call method to update inventory UI
    }

    // Method to update the inventory UI (to be implemented)
    private void UpdateInventoryUI()
    {
        // You'll implement this method to update the UI with the collected items
        // You can either handle UI updates directly here or call a separate method in the InventoryUI script
    }

    // Open or close the inventory
    public void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}


