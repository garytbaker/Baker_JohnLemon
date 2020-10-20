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

    public void spawnGhost()
    {
        Instantiate(ghost, new Vector3(4, 0, 4), Quaternion.identity);
        pointOfView = ghost.GetComponentInChildren<Observer>();
        setGhostData();
    }

    public void setGhostData()
    {
        pointOfView.player = GameObject.FindGameObjectWithTag("Player").transform;
        pointOfView.gameEnding = GetComponent<GameEnding>();
    }
}
