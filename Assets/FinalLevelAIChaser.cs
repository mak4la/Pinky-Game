using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FinalLevelAIChaser : MonoBehaviour
{
    public GameObject player;
    public float chaseSpeed = 8f;
    public float detectionRange = 10f;
    private FinalLevelAIPatrol patrolScript;
    private bool isChasing = false;

    void Start()
    {
        patrolScript = GetComponent<FinalLevelAIPatrol>();
        if (patrolScript == null)
        {
            Debug.LogError("FinalLevelAIChaser requires FinalLevelAIPatrol component!");
            enabled = false; // Disable the script if FinalLevelAIPatrol component is not found
        }
    }

    void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
            ChasePlayer();
        }
        else if (isChasing)
        {
            isChasing = false;
            ResumePatrol();
        }
    }

    void ChasePlayer()
    {
        // Calculate direction towards the player
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // Move towards the player
        transform.position += direction * chaseSpeed * Time.deltaTime;
    }

    void ResumePatrol()
    {
        // If the patrol script is available, resume patrolling
        if (patrolScript != null)
        {
            patrolScript.enabled = true;
        }
    }
}


