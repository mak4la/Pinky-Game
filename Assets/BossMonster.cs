using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossMonster : MonoBehaviour
{
    public AudioClip collisionSound; // Reference to the collision sound
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to this object
        audioSource = GetComponent<AudioSource>();
        // Add an AudioSource component if it doesn't exist
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        // Assign the collision sound to the AudioSource
        audioSource.clip = collisionSound;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroy(other.gameObject); // Destroy the player object
            //Kill();
            other.GetComponent<PlayerControl>().TakeDamage(1); // Damage the player by 1

        }
        if (other.CompareTag("Projectile"))
        {
            // Play the collision sound
            audioSource.Play();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
        //MonsterCounter.Mcounter.RegisterMonster();

    }
}

