using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitObject : MonoBehaviour
{
    public Rigidbody ObjectRigidbody;   // Referencia al Rigidbody del objeto Sol
    public float orbitSpeed = 10.0f;  // Velocidad de �rbita en grados por segundo
    public float orbitRadius = 10.0f; // Distancia orbital desde el Sol

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Calcula la posici�n orbital utilizando trigonometr�a
        float angle = orbitSpeed * Time.time;
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * orbitRadius;
        float z = Mathf.Sin(angle * Mathf.Deg2Rad) * orbitRadius;
        Vector3 newPosition = ObjectRigidbody.position + new Vector3(x, 0, z);

        // Mueve el objeto utilizando transform.position
        transform.position = newPosition;
    }

}














