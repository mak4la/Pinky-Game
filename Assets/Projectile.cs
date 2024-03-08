using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
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
                monster.Kill(); // Call the TakeDamage method of the monster
                Destroy(gameObject); // Destroy the projectile
            }
        }
    }
}
