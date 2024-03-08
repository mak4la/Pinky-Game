using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCounterText;
    public static CoinCounter Ccounter;
    int coinsCollected = 0;

    private void Awake()
    {
        if(Ccounter != null)
        {
            Destroy(this.gameObject);
        }

        Ccounter = this;
    }



    void Start()
    {

    }

    public void RegisterCoin()
    {
        coinsCollected += 1;
        coinCounterText.text = "COINS: " + coinsCollected.ToString();
    }
}
