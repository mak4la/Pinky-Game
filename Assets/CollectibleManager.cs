using UnityEngine;
using System.Collections.Generic;

public class CollectibleManager : MonoBehaviour
{
    // List to store collected items
    public List<Collectible> collectedItems = new List<Collectible>();

    // Make sure the CollectibleManager persists between scenes
    void Start()
    {
      
    }

    // Call this method whenever a new collectible is picked up
    public void AddCollectedItem(Sprite itemSprite)
    {
        // Create a new Collectible object using the provided sprite
        Collectible collectible = new Collectible();
        collectible.collectibleSprite = itemSprite;

        // Add the collected item to the list
        collectedItems.Add(collectible);
    }


}





