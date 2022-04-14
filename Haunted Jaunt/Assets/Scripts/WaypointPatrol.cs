using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public float ghostSpeed = 4f;
    private float currentspeed = 0f;
    int m_CurrentWaypointIndex;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        navMeshAgent.speed = currentspeed;
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            navMeshAgent.speed = 0f;
            currentspeed = 0f;
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        } else {
            currentspeed = (1.0f - .002f) * currentspeed + .002f * ghostSpeed;
            navMeshAgent.speed = currentspeed;
        }
    }
}