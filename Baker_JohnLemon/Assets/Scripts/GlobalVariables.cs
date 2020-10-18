using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour
{

    public int numberOfPlatforms;
    public int goalNumberOfPlatforms;
 

    public void addPlatform()
    {
        numberOfPlatforms += 1;
        if (numberOfPlatforms == goalNumberOfPlatforms)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
