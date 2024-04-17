using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour

{
    public AudioClip killSound; // The sound clip to play when the coin is collected
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Awake()
    {
        // Get the AudioSource component attached to the coin
        audioSource = GetComponent<AudioSource>();

        // Assign the collect sound to the AudioSource component
        if (killSound != null)
        {
            audioSource.clip = killSound;
        }
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //if (other.CompareTag("CoinCounter")) // Check for the "Coin" tag
    //{
    //Destroy(other.gameObject); // Destroy the coin
    //Destroy(gameObject); // Destroy the projectile


    //CoinCounter.Ccounter.RegisterCoin(); // Register the collected coin
    //}
    //else if (other.CompareTag("MonsterCounter")) // Check for the "Monster" tag
    //{
    //Destroy(other.gameObject); // Destroy the monster
    //Destroy(gameObject); // Destroy the projectile


    //MonsterCounter.Mcounter.RegisterMonster(); // Register the defeated monster
    //}

    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")) // Check for the "Monster" tag
        {
            Monster monster = other.GetComponent<Monster>(); // Get the Monster component
            if (monster != null)
            {
                if (audioSource != null && killSound != null)
                {
                    audioSource.PlayOneShot(killSound);
                }

                monster.Kill(); // Call the TakeDamage method of the monster
                Destroy(gameObject, audioSource.clip.length);

                //Destroy(gameObject); // Destroy the projectile
            }
        }
    }
}
