using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitObject : MonoBehaviour
{
    public Transform Object; // Asigna el objeto del Sol en el Inspector.
    public float orbitSpeed = 10.0f;

    void Update()
    {
        if (Object != null)
        {
            // Rota la Tierra alrededor del Sol.
            transform.RotateAround(Object.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }
    }
}














