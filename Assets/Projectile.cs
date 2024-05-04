using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AudioClip killSound; // The sound clip to play when the projectile hits the boss monster
    private AudioSource audioSource; // Reference to the AudioSource component
    public int bossDamage = 5; // Damage inflicted on the boss monster

    private void Awake()
    {
        // Get the AudioSource component attached to the projectile
        audioSource = GetComponent<AudioSource>();

        // Assign the kill sound to the AudioSource component
        if (killSound != null)
        {
            audioSource.clip = killSound;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
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
                monster.Kill(); // Call the Kill method of the monster
                Destroy(gameObject, audioSource.clip.length);
            }
        }
        else if (other.CompareTag("BossMonster")) // Check for the "BossMonster" tag
        {
            BossHealthBar bossHealthBar = other.GetComponent<BossHealthBar>();
            if (bossHealthBar != null)
            {
                //bossHealthBar.TakeDamage(bossDamage);// Deduct health from the boss monster
                    bossHealthBar.TakeDamage(bossDamage);// Deduct health from the boss monster
                
            }
            gameObject.SetActive(false); // Deactivate the projectile instead of destroying it
            //Destroy(gameObject); // Destroy the projectile after hitting the boss monster
        }
    }
}

