using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;  //the nav mesh agent of the ghost
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  //setting the destination to the first thing in the array of waypoints
    }

    // Update is called once per frame
    void Update()
    {
        //this iterates the index by one, but also makes it circle back by using modulus
            navMeshAgent.SetDestination(player.transform.position); //sets the new destination
    }
}
