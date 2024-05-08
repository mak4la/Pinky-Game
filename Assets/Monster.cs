using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroy(other.gameObject); // Destroy the player object
            //Kill();
            other.GetComponent<PlayerControl>().TakeDamage(1); // Damage the player by 1

        }
    }

    public void Kill()
    {
        gameObject.SetActive(false); // Deactivate the monster instead of destroying it
        //Destroy(gameObject);
        //MonsterCounter.Mcounter.RegisterMonster();
        
    }


}
