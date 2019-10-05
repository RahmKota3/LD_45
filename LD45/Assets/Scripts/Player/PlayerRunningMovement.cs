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

    [HideInInspector] public float MaxRbSpeed;

    Transform movementVector;

    float speed;
    Vector2 movement;
    float runningTime = 0;

    Rigidbody rb;

    void CheckInput()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement.y != 0)
            runningTime += Time.deltaTime;
        else
            runningTime = Mathf.Clamp01(runningTime - Time.deltaTime);
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
        Vector3 velocityVect = movementVector.forward * Mathf.Clamp(runningTime / maxClamp, 0, 5) * acceleration * Input.GetAxisRaw("Vertical");

        if (velocityVect.magnitude < maxSpeedMagnitude && movement.y > 0)
        {
            rb.velocity += velocityVect;
        }
        else if (movement.y > 0)
        {
            rb.velocity = movementVector.forward * MaxRbSpeed;
        }
        else if(movement.y < 0)
        {
            rb.velocity = -movementVector.forward * MaxRbSpeed / 5;
        }
    }

    void CreateMovementVector()
    {
        movementVector = new GameObject("MovementVector").transform;
        movementVector.rotation = transform.rotation;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        MaxRbSpeed = maxSpeedMagnitude * 40;

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
