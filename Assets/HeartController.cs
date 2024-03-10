using UnityEngine;

public class HeartController : MonoBehaviour
{
    public GameObject[] hearts;

    public void SetHeartState(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }
}

