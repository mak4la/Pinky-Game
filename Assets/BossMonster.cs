using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossMonster : MonoBehaviour
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

        Destroy(gameObject);
        MonsterCounter.Mcounter.RegisterMonster();

    }
}

