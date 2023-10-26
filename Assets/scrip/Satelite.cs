using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satelite : MonoBehaviour
{
    public Transform earth;           
    public Transform sun;              
    public float orbitSpeed = 10.0f;  
    public float orbitRadius = 3.0f;  
    public float rotationSpeed = 30.0f; 

    private float currentAngle = 0.0f;

    void Update()
    {
        // Rotación de la órbita
        currentAngle += orbitSpeed * Time.deltaTime;
        currentAngle = currentAngle % 360; // Mantener el ángulo dentro de un rango de 0 a 360 grados

        // Convertir el ángulo de grados a radianes
        float angleInRadians = currentAngle * Mathf.Deg2Rad;

        // Calcular las coordenadas x y z de la órbita alrededor de la Tierra
        float x = Mathf.Cos(angleInRadians) * orbitRadius;
        float z = Mathf.Sin(angleInRadians) * orbitRadius;

        // Calcular la posición relativa de la órbita alrededor de la Tierra
        Vector3 orbitPosition = earth.position + new Vector3(x, 0, z);
        transform.position = orbitPosition;

        // Rotar el satélite sobre su propio eje
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Alinear el satélite para que siempre mire al Sol
        Vector3 lookDirection = sun.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
