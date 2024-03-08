using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI monsterCounterText;
    public static MonsterCounter Mcounter;
    int monstersCollected = 0;

    private void Awake()
    {
        if (Mcounter != null)
        {
            Destroy(this.gameObject);
        }

        Mcounter = this;
    }



    void Start()
    {

    }

    public void RegisterMonster()
    {
        monstersCollected += 1;
        monsterCounterText.text = "MONSTERS: " + monstersCollected.ToString();
    }
}
