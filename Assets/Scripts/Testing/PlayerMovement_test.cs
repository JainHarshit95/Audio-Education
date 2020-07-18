using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_test : MonoBehaviour
{
    public CharacterController playerController;
    [SerializeField] private float playerSpeed =15f;
    [SerializeField] private float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    [SerializeField] private float jumpHeight = 3f;

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = SimpleInput.GetAxis("Horizontal");
        float moveZ = SimpleInput.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        playerController.Move(move *playerSpeed * Time.deltaTime);

       /* if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }*/

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }
}
