using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Velocity = 18;
    [SerializeField] float rotationSpeed = 0.5f;

    Transform target;
    bool lostTarget = false;

    float angle;

    Rigidbody rb;

    void FlyTowardsTarget()
    {
        if (target == null)
            return;

        angle = Vector3.Angle(target.transform.forward, (target.transform.position - transform.position).normalized);
        if (angle > 80 && angle <= 90)
            lostTarget = true;

        if (lostTarget == false)
        {
            Vector3 targetVector = (target.position - transform.position).normalized;

            transform.forward = Vector3.Slerp(transform.forward, targetVector, rotationSpeed / 100);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        rb.velocity = transform.forward * Velocity;
    }

    void FindTarget()
    {
        EntityStats[] possibleTargets = FindObjectsOfType<EntityStats>();
        float shortestDistance = Mathf.Infinity;
        float distance = 0;

        foreach (EntityStats es in possibleTargets)
        {
            if (this.transform == es.transform)
                continue;
            distance = Vector3.Distance(transform.position, es.transform.position);
            if(distance <= shortestDistance)
            {
                angle = Vector3.Angle(transform.forward, (es.transform.position - transform.position).normalized);
                if (angle >= 0 && angle < 45)
                {
                    shortestDistance = distance;
                    target = es.transform;
                }
            }
        }
    }

    private void Awake()
    {
        FindTarget();
        
        rb = GetComponent<Rigidbody>();
        
        rb.velocity = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity + transform.forward * Velocity;
    }

    private void FixedUpdate()
    {
        FlyTowardsTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
            return;

        EntityStats es = other.GetComponent<EntityStats>();
        if (es != null)
        {
            es.Stun();
        }
        
        Destroy(gameObject);
    }
}
