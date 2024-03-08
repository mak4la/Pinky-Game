using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaser : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Transform pointA;
    public Transform pointB;
    public float distanceBetween;
    public float chaseDistance;

    private bool isMovingToA = true; // Flag to track if the monster is moving towards point A
    private bool isChasing = false;  // Flag to track if the monster is currently chasing the player

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (isChasing)
        {
            // Chase the player
            Vector3 targetPosition = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if the player is out of chase distance
            if (distanceToPlayer > chaseDistance)
            {
                isChasing = false;
            }
        }
        else if (distanceToPlayer < chaseDistance)
        {
            // Start chasing the player
            isChasing = true;
        }
        else if (distanceToPlayer > distanceBetween)
        {
            // Patrol between points A and B
            PatrolBetweenPoints();
        }
    }

    private void PatrolBetweenPoints()
    {
        Vector3 targetPosition;

        if (isMovingToA)
        {
            targetPosition = pointA.position;
        }
        else
        {
            targetPosition = pointB.position;
        }

        // Move towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the monster has reached the target position
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Toggle the flag to switch between points
            isMovingToA = !isMovingToA;
        }
    }
}



