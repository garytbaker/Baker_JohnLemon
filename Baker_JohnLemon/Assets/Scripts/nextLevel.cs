using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    int levelNumber; //the build index of the current level
    // Start is called before the first frame update
    void Start()
    {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        if (levelNumber == 0)
        {
            levelNumber = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(levelNumber);
        }
    }
}
