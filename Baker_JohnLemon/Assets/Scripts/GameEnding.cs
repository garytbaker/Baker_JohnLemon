﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;  //the duration for how long the fade will happen
    public float displayImageDuration = 1f; // how long it will show the winning image
    public GameObject player;   //the player gameobjects reference
    public CanvasGroup exitBackgroundImageCanvasGroup;  //the canvas group for the fade to black and image

    bool m_IsPlayerAtExit;  //the boolean that determines if the player is at the exit
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
            EndLevel();  //then we will end the level
        }
    }

    void EndLevel()
    {
        m_Timer += Time.deltaTime;

        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }
}