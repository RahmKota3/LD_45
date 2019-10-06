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
        yield return new WaitForSeconds(0.5f);

        ActivateObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PowerupController>().RandomizePowerup();
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
