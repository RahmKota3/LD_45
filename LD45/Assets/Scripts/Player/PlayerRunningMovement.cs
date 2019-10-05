using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningMovement : MonoBehaviour
{
    [SerializeField] float acceleration;
    [SerializeField] float rotationSpeed;
    [SerializeField] float maxSpeedMagnitude = 1.25f;
    [SerializeField] float maxBackwardsSpeed = 16;
    [SerializeField] float maxClamp = 10;

    float maxRbSpeed;

    Transform movementVector;

    float speed;
    Vector2 movement;
    float runningTime = 0;

    Rigidbody rb;

    void CheckInput()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement != Vector2.zero)
            runningTime += Time.deltaTime;
        else
            runningTime = 0;
    }

    void RotateMovementVector()
    {
        movementVector.position = transform.position;
        //Debug.Log(rotationSpeed * Time.deltaTime * movement.x);
        movementVector.eulerAngles = new Vector3(0, movementVector.eulerAngles.y + rotationSpeed * Time.deltaTime * movement.x);
    }

    void RotatePlayer()
    {
        transform.rotation = movementVector.rotation;
    }

    void ApplyVelocity()
    {
        Vector3 velocityVect = movementVector.forward * Mathf.Clamp(runningTime / maxClamp, 0, 5) * acceleration;

        if (velocityVect.magnitude < maxSpeedMagnitude && movement.y != 0)
        {
            rb.velocity += velocityVect;
            Debug.Log(rb.velocity.magnitude + ", ");
        }
        else if (movement.y != 0)
        {
            rb.velocity = movementVector.forward * maxRbSpeed;
        }
    }

    void CreateMovementVector()
    {
        movementVector = new GameObject("MovementVector").transform;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        maxRbSpeed = maxSpeedMagnitude * 40;

        CreateMovementVector();
    }

    private void Update()
    {
        CheckInput();
        RotateMovementVector();
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        ApplyVelocity();
    }
}
