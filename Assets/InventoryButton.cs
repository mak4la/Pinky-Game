using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        GetComponent<Button>().onClick.AddListener(ToggleInventory);
    }

    private void ToggleInventory()
    {
        playerInventory.ToggleInventory();
    }
}

