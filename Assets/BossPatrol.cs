using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour
{
    public Transform[] patrolPoints; // Array of patrol points
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float detectionRange = 5f;

    private Transform target; // Reference to the target (player)
    private bool isChasing = false; // Flag to indicate if the boss is chasing the player
    private int currentPatrolPointIndex = 0; // Index of the current patrol point

    private void Start()
    {
        // Assuming the player character has a "Player" tag
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Calculate the distance to the target
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget < detectionRange)
        {
            // If the player is within the detection range, start chasing
            isChasing = true;
        }

        if (isChasing)
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, target.position, chaseSpeed * Time.deltaTime);

            // Check if the player is out of range
            if (distanceToTarget > detectionRange)
            {
                isChasing = false;
            }
        }
        else
        {
            // Patrol between patrol points
            Patrol();
        }
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0)
        {
            Debug.LogWarning("No patrol points defined!");
            return;
        }

        // Move towards the current patrol point
        Transform currentPatrolPoint = patrolPoints[currentPatrolPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, currentPatrolPoint.position, patrolSpeed * Time.deltaTime);

        // Check if the boss has reached the current patrol point
        if (Vector2.Distance(transform.position, currentPatrolPoint.position) < 0.1f)
        {
            // Move to the next patrol point
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
        }
    }
}
