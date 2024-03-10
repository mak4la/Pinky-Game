using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInventory>().AddItem(gameObject); // Add the collectible to the player's inventory
            gameObject.SetActive(false); // Hide the collectible
        }
    }
}
