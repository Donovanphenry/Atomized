using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;

    // Variables for moving the camera
    public float turnSmoothTime = .1f;
    private float turnSmoothVelocity;
    public Transform cam;

    // Movement Variables
    public float groundMovementSpeed = 6f;
    public float movementSpeed = 0f;
    public float gravity = -9.81f;
    public Vector3 velocity;
    public float jumpForce = .5f;

    // Variables helping to determine if player is in air
    public float groundDistance = .4f;
    public LayerMask groundMask;
    public Transform groundCheck;
    private bool grounded = true;
    
    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if ((Input.GetKeyDown("a") || Input.GetKeyDown("d")) && !grounded)
            movementSpeed = movementSpeed + .7f;

        if (Input.GetKeyDown("space") && grounded)
        {
            velocity.y += jumpForce;
            grounded = false;
        }

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2;
            movementSpeed = groundMovementSpeed;
            grounded = true;
        }


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Enter if movement occurs (input == w a s d)
        if (direction.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
                ref turnSmoothVelocity, turnSmoothTime);


            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * movementSpeed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}