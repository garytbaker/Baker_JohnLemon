using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;  //the duration for how long the fade will happen
    public float displayImageDuration = 1f; // how long it will show the winning image
    public GameObject player;   //the player gameobjects reference
    public CanvasGroup exitBackgroundImageCanvasGroup;  //the canvas group for the fade to black and image
    public CanvasGroup caughtBackgroundImageCanvasGroup; // canvas group dor when the player is caught

    bool m_IsPlayerAtExit;  //the boolean that determines if the player is at the exit
    bool m_IsPlayerCaught;  //bool determining if the player is caught

    float m_Timer;          //the timer to see how long we are at the end of the level

    void OnTriggerEnter(Collider other)  //this is to determine if the player has walked into the game ending box collider
    {
        if (other.gameObject == player)  //if the it in fact the player
        {
            m_IsPlayerAtExit = true;   //then they are at the exit
        }
    }

    void Update()  //calling the update function
    {
        if (m_IsPlayerAtExit)  //if the player is at teh end of the level
        {
            EndLevel(exitBackgroundImageCanvasGroup);  //then we will end the level
        }
        else if (m_IsPlayerCaught)  //if the player is caught
        {
            EndLevel(caughtBackgroundImageCanvasGroup);  //edn the level
        }
    }

    /// <summary>
    /// this function actually ends the game
    /// <paramref name="imageCanvasGroup"/>the canvas group is what you want to fade in
    /// </summary>
    void EndLevel(CanvasGroup imageCanvasGroup)  
    {
        m_Timer += Time.deltaTime;  //iterates the time making a makeshift timer

        imageCanvasGroup.alpha = m_Timer / fadeDuration; //the fade value is the amount of time divided by the fade duration ranges from 0-1

        if (m_Timer > fadeDuration + displayImageDuration)  //if the timer is greater than the duration of the two fade timers
        {
            Application.Quit();  //quit the game
        }
    }
}