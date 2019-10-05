using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float knockback = 100;

    Rigidbody rb;
    PlayerRunningMovement movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<PlayerRunningMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal != Vector3.up)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
