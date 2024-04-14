using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip collectSound; // The sound clip to play when the coin is collected
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Awake()
    {
        // Get the AudioSource component attached to the coin
        audioSource = GetComponent<AudioSource>();

        // Assign the collect sound to the AudioSource component
        if (collectSound != null)
        {
            audioSource.clip = collectSound;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerControl>() != null)
        {
            Pickup();

        }
    }

    void Pickup()
    {
        // Play the collect sound
        if (audioSource != null)
        {
            audioSource.Play();
        }
        Destroy(gameObject, audioSource.clip.length);

        CoinCounter.Ccounter.RegisterCoin();

    }

}
