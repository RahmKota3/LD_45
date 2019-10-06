using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    [SerializeField] GameObject model;
    Collider col;

    [SerializeField] float rotationSpeed;

    void DeactivateObject()
    {
        model.SetActive(false);
        col.enabled = false;
    }

    void ActivateObject()
    {
        model.SetActive(true);
        col.enabled = true;
    }

    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(5);

        ActivateObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        PowerupController pc = other.gameObject.GetComponent<PowerupController>();

        if (pc == null)
            return;

        pc.RandomizePowerup();
        StartCoroutine(RespawnCoroutine());
        DeactivateObject();
    }

    private void Awake()
    {
        col = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        model.transform.Rotate(new Vector3(0, rotationSpeed));
    }
}
