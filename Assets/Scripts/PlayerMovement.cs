using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    
    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    public HealthBar healthBar;
    
    DateTime StartFalling;
    private Vector3 velocity;
    private CharacterController controller;
    private bool isGrounded;

    private bool isntChecked=false;

    public Initial initial;
    public GameOverbg gameover;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        healthBar.Start();
        initial.Start();
        gameover.start();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            if (isntChecked)
            {
                isntChecked=false;
                TimeSpan difference = DateTime.UtcNow.Subtract(StartFalling);
                int result = (int)difference.TotalMilliseconds;
                if (result>1000)
                {
                    healthBar.SetHealth((result-1000)/20);
                }
            }
        }

        

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        controller.Move(moveDirection * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            StartFalling=DateTime.UtcNow;
            isntChecked=true;
        }

        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);
    }
}
