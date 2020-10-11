using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;  //the location of the player
    public GameEnding gameEnding;  // to determine if the game is going to be ending

    bool m_IsPlayerInRange;  //determing that the player is either in or not in range of the gargoyle's Line of Sight

    void OnTriggerEnter(Collider other)  //determining if the player is in the line of sight collider
    {
        if (other.transform == player)  //if it is the player
        {
            m_IsPlayerInRange = true;  //then the player is in range
        }
    }

    void OnTriggerExit(Collider other)  //this is for when John lemon leaves the range, useful for when a wall is in the way
    {
        if (other.transform == player) //if the player left the range
        {
            m_IsPlayerInRange = false;  //then he is no longer in range
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)  //if the player is in range
        {
            Vector3 direction = player.position - transform.position + Vector3.up;  //this gets the direction for the raycast to determine if it is a wall or a player first
            Ray ray = new Ray(transform.position, direction);  //making a ray from the PointOfViewObj towards the palyer
            RaycastHit raycastHit;  //what gets touched by the raycast

            if (Physics.Raycast(ray, out raycastHit)) //if the ray hits something, and saves the datat to raycast hit
            {
                if (raycastHit.collider.transform == player)  //if the player is what was hit
                {
                    gameEnding.CaughtPlayer();//calls the caught player script
                }
            }
        }
    }
}