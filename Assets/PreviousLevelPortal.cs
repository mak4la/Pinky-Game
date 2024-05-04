using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PreviousLevelPortal : MonoBehaviour
{
    private bool playerInRange = false;
    private float timer = 0f;
    private float teleportDelay = 5f;

    private void Update()
    {
        if (playerInRange)
        {
            timer += Time.deltaTime;
            if (timer >= teleportDelay)
            {
                TeleportPlayer();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            timer = 0f; // Reset the timer when the player exits the trigger
        }
    }

    private void TeleportPlayer()
    {
        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the previous scene
        SceneManager.LoadScene(currentSceneIndex - 1);
    }
}
