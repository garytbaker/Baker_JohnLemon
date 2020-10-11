using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;  //the speed to turn

    Animator m_Animator;   //the animator of John Lemon
    Rigidbody m_Rigidbody; //the rigidbody of John lemon
    AudioSource m_AudioSource;  //the source for the footsteps
    Vector3 m_Movement;  //the movement saved as a vector3 from the input
    Quaternion m_Rotation = Quaternion.identity;  //setting rotation to the default

    void Start()
    {
        m_Animator = GetComponent<Animator>();   //setting the animator and the rigidbody to be manipulated in teh script
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>()//getting the reference for the audio for the footsteps
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");  //getting input from the input system so wasd and arrow keys work
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);  //setting the movement vector
        m_Movement.Normalize();  //using pythangorems theorem to normalize the vector so the character goes at an equal spped diagonally

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);  //these two lines determine if there is player input
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;  //this line is is setting isWalking to true if there is input horizontally or vertically
        m_Animator.SetBool("IsWalking", isWalking);  //then this sets the isWalking parameter for the animation to true if the player is walking

        if (isWalking) //if john lemon is walking
        {
            if (!m_AudioSource.isPlaying)  //and the footsteps are not playing
            {
                m_AudioSource.Play();  //play the sound
            }
        }
        else  
        {
            m_AudioSource.Stop(); //if john lemon is not walking stop the footsteps sound
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);  //setting the direction we want John lemon to face and slowing his turning down
        m_Rotation = Quaternion.LookRotation(desiredForward);  //actually setting the rotation to what we want it to be
    }

    void OnAnimatorMove()  //this function is needed to move and rotate an animated character
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);  //moving John lemon to the new position
        m_Rigidbody.MoveRotation(m_Rotation);  //rotating john lemon
    }
}