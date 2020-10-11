using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;  //the nav mesh agent of the ghost
    public Transform[] waypoints;  //the set of waypoints the ghost will go through

    int m_CurrentWaypointIndex;  //the index of the array that we are at


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);  //setting the destination to the first thing in the array of waypoints
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)  //checking to see if the navmeshagent has arrived at its destination
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;  //this iterates the index by one, but also makes it circle back by using modulus
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position); //sets the new destination
        }
    }
}
