using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float gravity = 1.0f;
    [SerializeField] private float jumpHeight = 15.0f;

    private CharacterController controller;

    private float yVelocity;
    private Vector3 velocity;

    [SerializeField] private float gravityValue = -9.8f;

    [SerializeField] private int coins = 0;

    private bool jumping = false;
    private bool canDoubleJump = true;
    private bool groundedPlayer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && velocity.y < 0)
        {
            velocity.y = 0.0f;
        }

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        controller.Move(moveDirection * Time.deltaTime * movementSpeed);

        if (moveDirection != Vector3.zero)
        {
            //gameObject.transform.forward = moveDirection;
        }

        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            canDoubleJump = true;
        }
        else if (canDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            canDoubleJump = false;
        }

        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
/*
void Update()
{
    Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    velocity = moveDirection * movementSpeed;
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Debug.Log("Jump");
    }
    if (controller.isGrounded)
    {
        jumping = false;
        canDoubleJump = true;
        yVelocity = 0.0f; 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump with prior y velocity of " + yVelocity);
            yVelocity += jumpHeight;
            jumping = true;
            canDoubleJump = true;
        }
    }
    else
    {
        if (jumping && canDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            yVelocity += jumpHeight;
            canDoubleJump = false;
        }
        else
        {
            yVelocity -= gravity;
            yVelocity = Mathf.Clamp(yVelocity, -9.8f, 1000.0f);
        }
    }
    //Debug.Log("YVelocity is " + yVelocity);

    velocity.y = yVelocity;
    controller.Move(velocity * Time.deltaTime);
}
*/

    private void FixedUpdate()
    {
        //controller.Move(velocity * Time.fixedDeltaTime);
    }

    public void AddCoins(int coinValue)
    {
        coins += coinValue;
        UIManager.Instance.UpdateCoins(coins);
    }
}