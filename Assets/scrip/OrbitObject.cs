using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitObject : MonoBehaviour
{
    public Transform Object;             // Referencia al objeto 
    public float orbitSpeed = 10.0f;  // Velocidad de �rbita en grados por segundo
    public float orbitRadius = 10.0f; // Distancia orbital

    private float currentAngle = 0.0f;

    private Vector3 sunPosition;

    void Start()
    {
        sunPosition = Object.position;
    }

    void Update()
    {
        // Si la posici�n del Sol ha cambiado, actualizar la posici�n de referencia de la Tierra
        if (Object.position != sunPosition)
        {
            Vector3 deltaPosition = Object.position - sunPosition;
            transform.position += deltaPosition;
            sunPosition = Object.position;
        }

        // Calcular la nueva posici�n de la Tierra en funci�n del tiempo y la distancia orbital
        currentAngle += orbitSpeed * Time.deltaTime;
        currentAngle = currentAngle % 360; // Mantener el �ngulo dentro de un rango de 0 a 360 grados

        // Convertir el �ngulo de grados a radianes
        float angleInRadians = currentAngle * Mathf.Deg2Rad;

        float x = Mathf.Cos(angleInRadians) * orbitRadius;
        float z = Mathf.Sin(angleInRadians) * orbitRadius;

        // Establecer la posici�n relativa de la Tierra al Sol
        Vector3 newPosition = Object.position + new Vector3(x, 0, z);
        transform.position = newPosition;

        // Rotar la Tierra sobre su propio eje
        transform.Rotate(Vector3.up * orbitSpeed * Time.deltaTime);
    }
}














