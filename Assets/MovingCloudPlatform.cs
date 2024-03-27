using UnityEngine;

public class MovingCloudPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float arrivalTolerance = 0.1f; // Tolerance for reaching the target position

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = pointB.position;
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if reached the target position
        if (Vector3.Distance(transform.position, pointA.position) <= arrivalTolerance)
        {
            targetPosition = pointB.position; // Move towards point B
        }
        else if (Vector3.Distance(transform.position, pointB.position) <= arrivalTolerance)
        {
            targetPosition = pointA.position; // Move towards point A
        }
    }

}




