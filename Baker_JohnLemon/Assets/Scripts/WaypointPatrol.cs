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
        player = GameObject.FindGameObjectWithTag("Player");  //setting the player top the current player in Unity
    }

    // Update is called once per frame
    void Update()
    {
            navMeshAgent.SetDestination(player.transform.position); //sets the new destination to the player every frame
    }
}
