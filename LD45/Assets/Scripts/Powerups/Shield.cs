using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    float rotationSpeed = 2;

    private void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }
}
