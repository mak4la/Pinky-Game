using UnityEngine;

public class FinalLevelAIPatrol : MonoBehaviour
{
    public float patrolSpeed = 5f;
    public Transform[] patrolPoints;
    public float stoppingDistance = 0.1f;
    public GameObject player;


    private int currentPatrolIndex = 0;

    void Start()
    {
        if (patrolPoints.Length == 0)
        {
            Debug.LogError("Patrol points are not set for AI patrol.");
            enabled = false; // Disable the script if no patrol points are set
        }
    }

    void Update()
    {
        if (patrolPoints.Length == 0)
            return;

        // Move towards the current patrol point
        Vector3 targetPosition = patrolPoints[currentPatrolIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, patrolSpeed * Time.deltaTime);

        // Check if the monster has reached the patrol point
        if (Vector3.Distance(transform.position, targetPosition) < stoppingDistance)
        {
            // Move to the next patrol point
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }
}
