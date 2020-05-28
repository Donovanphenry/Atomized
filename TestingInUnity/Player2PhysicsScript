using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Physics : MonoBehaviour
{
    public Rigidbody rb;
    public float custForce_xComponent = 0, custForce_yComponent = 1500, custForce_zComponent = 3000;
    public float movementForce_x = 0, movementForce_y = 0, movementForce_z = 0;
    private bool movingLeft, movingRight, movingBack, movingForward;
	// Use this for initialization
	void Start ()
    {
        Debug.Log("I'm 10 and 11!");

        // rb.useGravity = false; Would stop gravity from affecting its net force
        //rb.AddForce(0, 0, 150); // F_rb_initial = <0, 0, 150>
	}

    void Update()
    {
        //Checking for right-left movement
        if (Input.GetKey("a"))
            movingLeft = true;
        if (Input.GetKey("d"))
            movingRight = true;

        //Checking for forward-backward movement
        if (Input.GetKey("w"))
            movingForward = true;
        if (Input.GetKey("s"))
            movingBack = true;
    }
	
	// FixedUpdate is called once per frame and preferred by Unity compiler when making physics adjustments as opposed to Update
	void FixedUpdate ()
    {
        // rb.AddForce(0, custForce_yComponent * Time.deltaTime, custForce_zComponent * Time.deltaTime); // F_rb_constant = <0, 1500 * (change in time), 3000 * (change in time)>

        //Forward-Backward Inputs
        if (movingForward)
        {
            rb.AddForce(0, 0, movementForce_z * Time.deltaTime, ForceMode.VelocityChange);
            movingForward = false;
        }
        if (movingBack)
        {
            rb.AddForce(0, 0, -1 * movementForce_z * Time.deltaTime, ForceMode.VelocityChange);
            movingBack = false;
        }

        //Left-Right Inputs
        if (movingLeft)
        {
            rb.AddForce(-1 * movementForce_x * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            movingLeft = false;
        }

        if (movingRight)
        {
            rb.AddForce(movementForce_x * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            movingRight = false;
        }

	}
}

