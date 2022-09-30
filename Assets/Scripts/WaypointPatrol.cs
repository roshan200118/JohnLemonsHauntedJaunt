using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    //Reference NavMeshAgent and way points
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    //Keep track of waypoint index
    int m_CurrentWaypointIndex;

    void Start()
    {
        //Set inital destination of nav mesh agent
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        //Check if nav mesh agent is at destination 
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            //Change waypoint index 
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;

            //Set destination for new waypoint
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}