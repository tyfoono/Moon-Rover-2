using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float maxAngSpeed = 20;

    public bool isMovingForward = false;
    public bool isMovingBackwards = false;
    public bool isRotatingRight = false;
    public bool isRotatingLeft = false;

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //for FixedUpdate:

    private void FixedUpdate()
    {
        // tidied up the if statements, you don't need to compare a bool, you can use it directly
        Quaternion deltaRotation;
        Vector3 AngularVel = Vector3.zero;

        // generate a sign dependent angular velocity about y (up)
        if (isRotatingRight)
        {
            AngularVel = transform.up * maxAngSpeed;
        }
        else if (isRotatingLeft)
        {
            AngularVel = transform.up * -maxAngSpeed;
        }

        // convert your angular velocity to a quaternion angle change
        deltaRotation = Quaternion.Euler(AngularVel * Time.fixedDeltaTime);

        // mulitply the current rotation quaternion by the quaternion change (delta) and move to that new rotation
        // for quaternions, multiplying can be thought of as like adding Euler  angles
        rb.MoveRotation(deltaRotation * rb.rotation);

        // do the rotation first, then you can just move forward
        if (isMovingForward)
        {
            rb.MovePosition(rb.position + maxSpeed * Time.fixedDeltaTime * transform.forward);
        }
        else if (isMovingBackwards)
        {
            rb.MovePosition(rb.position - maxSpeed * Time.fixedDeltaTime * transform.forward);
        }

    }
}