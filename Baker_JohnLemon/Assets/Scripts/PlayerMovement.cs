using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;  //the speed to turn

    Animator m_Animator;   //the animator of John Lemon
    Rigidbody m_Rigidbody; //the rigidbody of John lemon
    Vector3 m_Movement;  //the movement saved as a vector3 from the input
    Quaternion m_Rotation = Quaternion.identity;

    void Start()
    {
        m_Animator = GetComponent<Animator>();   //setting the animator and the rigidbody to be manipulated in teh script
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");  //getting input from the input system so wasd and arrow keys work
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);  //setting the movement vector
        m_Movement.Normalize();  //using pythangorems theorem to normalize the vector so the character goes at an equal spped diagonally

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);  //these two lines determine if there is player input
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}