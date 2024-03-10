using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject inventoryUI; // Reference to the inventory UI panel
    public List<GameObject> collectedItems = new List<GameObject>(); // List to store collected items

    // Add item to the inventory
    public void AddItem(GameObject item)
    {
        collectedItems.Add(item);
    }

    // Open or close the inventory
    public void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}

