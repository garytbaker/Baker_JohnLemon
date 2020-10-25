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
        levelNumber = SceneManager.GetActiveScene().buildIndex;  //gets the nuild index of the current leve
        if (levelNumber == 0)  //if it is the home page
        {
            levelNumber = 1;  //it is now the first level
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))  //when space is pressed
        {
            SceneManager.LoadScene(levelNumber);  //restart the level
        }
    }
}
