using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCounterText;
    public static CoinCounter Ccounter;

    private int coinsCollected = 0;
    private int totalCoins; // Total number of coins in the scene
    private PlayerControl player; // Reference to the player

    private void Awake()
    {
        if (Ccounter != null)
        {
            Destroy(this.gameObject);
        }
        Ccounter = this;
    }

    void Start()
    {
        // Initialize total number of coins in the scene
        totalCoins = FindObjectsOfType<Coin>().Length; // Assuming you have a Coin script for your coin objects

        // Update the coin counter text
        coinCounterText.text = "COINS: 0/" + totalCoins;

        // Find the player control script in the scene
        player = FindObjectOfType<PlayerControl>();
    }

    public void RegisterCoin()
    {
        coinsCollected++;

        // Update the coin counter text
        coinCounterText.text = "COINS COLLECTED: " + coinsCollected;

        Debug.Log("Coin collected! Total: " + coinsCollected);

        // Check if every 5 coins are collected to regenerate a heart
        if (coinsCollected % 5 == 0)
        {
            RegenerateHeart();
        }
    }

    private void RegenerateHeart()
    {
        // Check if player exists and current health is less than max health
        if (player != null && player.currentHealth < player.maxHealth)
        {
            // Regenerate a heart
            player.RestoreLife();
            Debug.Log("Heart regenerated! Current Health: " + player.currentHealth);
        }
    }
}
