using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;  //the duration for how long the fade will happen
    public float displayImageDuration = 1f; // how long it will show the winning image
    public GameObject player;   //the player gameobjects reference
    public CanvasGroup exitBackgroundImageCanvasGroup;  //the canvas group for the fade to black and image
    public CanvasGroup caughtBackgroundImageCanvasGroup; // canvas group dor when the player is caught
    public AudioSource exitAudio;  //different sound effects
    public AudioSource caughtAudio;

    bool m_IsPlayerAtExit;  //the boolean that determines if the player is at the exit
    bool m_IsPlayerCaught;  //bool determining if the player is caught
    bool m_HasAudioPlayed;  //bool determining if the audio has played

    float m_Timer;          //the timer to see how long we are at the end of the level

    void OnTriggerEnter(Collider other)  //this is to determine if the player has walked into the game ending box collider
    {
        if (other.gameObject == player)  //if the it in fact the player
        {
            m_IsPlayerAtExit = true;   //then they are at the exit
        }
    }

    public void CaughtPlayer()  //function to be called by another class
    {
        m_IsPlayerCaught = true;  //sets the caught to be true
    }

    void Update()  //calling the update function
    {
        if (m_IsPlayerAtExit)  //if the player is at teh end of the level
        {
            EndLevel(exitBackgroundImageCanvasGroup, false,exitAudio);  //then we will end the level
        }
        else if (m_IsPlayerCaught)  //if the player is caught
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);  //edn the level
        }
    }

    /// <summary>
    /// this function actually ends the game
    /// <paramref name="imageCanvasGroup"/>the canvas group is what you want to fade in
    /// <paramref name="doRestart"/>if teh game should restart or not
    /// <paramref name="audioSource"/>the audio source to be played
    /// </summary>
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }


        m_Timer += Time.deltaTime;  //iterates the time making a makeshift timer

        imageCanvasGroup.alpha = m_Timer / fadeDuration; //the fade value is the amount of time divided by the fade duration ranges from 0-1

        if (m_Timer > fadeDuration + displayImageDuration)  //if the timer is greater than the duration of the two fade timers
        {
            if (doRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                Application.Quit();  //quit the game
            }

        }

    }
}