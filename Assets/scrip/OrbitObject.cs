using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitObject : MonoBehaviour
{
    public Transform Object;             // Referencia al objeto 
    public float orbitSpeed = 10.0f;  // Velocidad de órbita en grados por segundo
    public float orbitRadius = 10.0f; // Distancia orbital

    private float currentAngle = 0.0f;

    private Vector3 sunPosition;

    void Start()
    {
        sunPosition = Object.position;
    }

    void Update()
    {
        // Si la posición del Sol ha cambiado, actualizar la posición de referencia de la Tierra
        if (Object.position != sunPosition)
        {
            Vector3 deltaPosition = Object.position - sunPosition;
            transform.position += deltaPosition;
            sunPosition = Object.position;
        }

        // Calcular la nueva posición de la Tierra en función del tiempo y la distancia orbital
        currentAngle += orbitSpeed * Time.deltaTime;
        currentAngle = currentAngle % 360; // Mantener el ángulo dentro de un rango de 0 a 360 grados

        // Convertir el ángulo de grados a radianes
        float angleInRadians = currentAngle * Mathf.Deg2Rad;

        float x = Mathf.Cos(angleInRadians) * orbitRadius;
        float z = Mathf.Sin(angleInRadians) * orbitRadius;

        // Establecer la posición relativa de la Tierra al Sol
        Vector3 newPosition = Object.position + new Vector3(x, 0, z);
        transform.position = newPosition;

        // Rotar la Tierra sobre su propio eje
        transform.Rotate(Vector3.up * orbitSpeed * Time.deltaTime);
    }
}














