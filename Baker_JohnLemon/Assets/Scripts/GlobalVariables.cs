using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour
{

    public int numberOfPlatforms;  //the number of platforms that currently have a box on them
    public int goalNumberOfPlatforms;  //the number needed to go to the next level
    public GameObject ghost;  //the ghost that will spawn
    private bool spawned;  //if the ghost has spawned already
    public float spawnTimer = 60.0f;  //how long until the ghost will spawn. base is one minute
    public Observer pointOfView;  //this is the point of view of the ghost that is spawned

    /// <summary>
    /// This is a function that adds one to the number of platforms with boxes on them
    /// </summary>
    public void addPlatform()
    {
        numberOfPlatforms += 1;
        if (numberOfPlatforms == goalNumberOfPlatforms)  //if the number is the goal
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  //go to the next level
        }
    }

    /// <summary>
    /// This is to take off a platform when a boxe moves off of the platform
    /// </summary>
    public void deletePlatform()
    {
        numberOfPlatforms -= 1;
    }


    //using update as the timer function
    public void Update()
    {
        spawnTimer -= Time.deltaTime;//iterates the time
        if (spawnTimer <= 0.0f && spawned ==false) //if the timer has been reached
        {
            spawned = true;  //set spawned to true to only spawn one ghost
            spawnGhost();  //then spawn the ghost
        }
    }

    /// <summary>
    /// this functions spawns in the ghost
    /// </summary>
    public void spawnGhost()
    {
        GameObject newGhost = Instantiate(ghost, new Vector3(4, 0, 4), Quaternion.identity);  //makes the new ghost
        newGhost.layer = 9;//makes the new ghost on the ghost layer
        pointOfView = newGhost.GetComponentInChildren<Observer>(); //sets opintOfView to the observer that controls resetting the level
        setGhostData(); //then changes the data for the observer
    }

    /// <summary>
    /// This functions sets the data for the observer of the ghost so the level can restart
    /// </summary>
    public void setGhostData()
    {
        pointOfView.player = GameObject.FindGameObjectWithTag("Player").transform; //sets the player to the currenty player in Unity
        pointOfView.gameEnding = GetComponent<GameEnding>();  //sets the gameEnding to the gameEnding of the level controller of the current level
    }
}
