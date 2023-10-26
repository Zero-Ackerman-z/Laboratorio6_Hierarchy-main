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
        // Rotaci�n de la �rbita
        currentAngle += orbitSpeed * Time.deltaTime;
        currentAngle = currentAngle % 360; // Mantener el �ngulo dentro de un rango de 0 a 360 grados

        // Convertir el �ngulo de grados a radianes
        float angleInRadians = currentAngle * Mathf.Deg2Rad;

        // Calcular las coordenadas x y z de la �rbita alrededor de la Tierra
        float x = Mathf.Cos(angleInRadians) * orbitRadius;
        float z = Mathf.Sin(angleInRadians) * orbitRadius;

        // Calcular la posici�n relativa de la �rbita alrededor de la Tierra
        Vector3 orbitPosition = earth.position + new Vector3(x, 0, z);
        transform.position = orbitPosition;

        // Rotar el sat�lite sobre su propio eje
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Alinear el sat�lite para que siempre mire al Sol
        Vector3 lookDirection = sun.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
