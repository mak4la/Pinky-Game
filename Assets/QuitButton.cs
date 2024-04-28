using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    // Method to handle the quit button click event
    public void QuitGame()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
