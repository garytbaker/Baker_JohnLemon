using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour
{

    public int numberOfPlatforms;
    public int goalNumberOfPlatforms;
    public GameObject ghost;
    private bool spawned;
    public float spawnTimer = 60.0f;

    public void addPlatform()
    {
        numberOfPlatforms += 1;
        if (numberOfPlatforms == goalNumberOfPlatforms)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void deletePlatform()
    {
        numberOfPlatforms -= 1;
    }

    public void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0.0f && spawned ==false)
        {
            spawned = true;
            spawnGhost();
        }
    }

    public void spawnGhost()
    {
        Instantiate(ghost, new Vector3(4, 0, 4), Quaternion.identity);
        Observer PointOfView = ghost.GetComponentInChildren<Observer>();
        PointOfView.player = GameObject.FindGameObjectWithTag("Player").transform;
        PointOfView.gameEnding = GetComponent<GameEnding>();
    }

}
