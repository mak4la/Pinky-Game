using UnityEngine;
using System.Collections.Generic;

public class CollectibleManager : MonoBehaviour
{
    // List to store collected collectible game objects
    public List<GameObject> collectedItems = new List<GameObject>();

    // Call this method whenever a new collectible is picked up
    public void AddCollectedItem(GameObject collectible)
    {
        // Add the collected item to the list
        collectedItems.Add(collectible);
        Debug.Log("Added collectible. Total collected: " + collectedItems.Count);

    }

    // Method to check if all 4 collectibles are collected
    public bool AllCollectiblesCollected()
    {
        // Check if the number of collected items equals 4
        bool allCollected = collectedItems.Count == 4;
        Debug.Log("All collectibles collected: " + allCollected);
        return allCollected;
    }
}






