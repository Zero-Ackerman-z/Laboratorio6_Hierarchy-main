using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satelite : MonoBehaviour
{
    public Transform sun;              // Referencia al objeto Sol
    public float lookAtSpeed = 10.0f;  // Velocidad de mirar al Sol
    void Start()
    {

    }

    void Update()
    {
        Vector3 lookDirection = sun.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = targetRotation;
    }
}
