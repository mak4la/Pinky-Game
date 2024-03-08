using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Destroy the player object
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(this.gameObject);
        MonsterCounter.Mcounter.RegisterMonster();

    }


}
