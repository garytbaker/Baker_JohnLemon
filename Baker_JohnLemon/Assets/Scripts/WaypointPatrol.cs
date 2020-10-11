using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;  //the nav mesh agent of the ghost
    public Transform[] waypoints;  //the set of waypoints the ghost will go through
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);  //setting the destination to the first thing in the array of waypoints
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
