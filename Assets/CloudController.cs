using UnityEngine;

public class CloudController : MonoBehaviour
{
    private Vector3 initialPosition;
    public float resetThreshold = -1f; // Set this to the threshold value below which clouds are considered to have fallen off

    private void Start()
    {
        // Record the initial position of the cloud
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Check if the cloud has fallen below the threshold
        if (transform.position.y < resetThreshold)
        {
            // Reset the cloud to its initial position
            ResetCloud();
        }
    }

    private void ResetCloud()
    {
        // Reset the position of the cloud to its initial position
        transform.position = initialPosition;
        // Optionally, you can reset any other properties of the cloud here (e.g., velocity, rotation)
    }
}


