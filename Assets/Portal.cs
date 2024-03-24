using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextSceneName; // Name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the portal trigger zone.");

            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Load the next scene using SceneManager
        SceneManager.LoadScene(nextSceneName);
    }
}


