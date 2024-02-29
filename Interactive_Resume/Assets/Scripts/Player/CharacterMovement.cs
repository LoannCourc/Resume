using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public float turnSpeed = 180.0f;

    private float horizontalMovement;
    private float verticalMovement;

    void Update()
    {
        HandleInput();
        HandleMovement();
    }

    void HandleInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.Q))
        {
            horizontalMovement -= 1;
        }
        if (Input.GetKey(KeyCode.D))                                             
        {
            horizontalMovement += 1;
        }

        verticalMovement = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            verticalMovement *= runSpeed;
        }
        else
        {
            verticalMovement *= walkSpeed;
        }
    }

    void HandleMovement()
    {
        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement).normalized * Time.deltaTime;

        transform.position += transform.forward * verticalMovement * Time.deltaTime;
        transform.Rotate(0, horizontalMovement * turnSpeed * Time.deltaTime, 0);
    }
}