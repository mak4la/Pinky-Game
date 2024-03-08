using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerControl>() != null)
        {
            Pickup();

        }
    }

    void Pickup()
    {
        Destroy(this.gameObject);
        CoinCounter.Ccounter.RegisterCoin();

    }

}
