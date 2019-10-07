using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EntityStats es = other.GetComponent<EntityStats>();

        if (es == null)
            return;

        es.Stun();

        Destroy(gameObject);
    }
}
