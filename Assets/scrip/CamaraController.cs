using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    [SerializeField] Transform target; // El objeto que la c�mara seguir�
    public Vector3 offset = new Vector3(0, 5, -10); // Offset de la c�mara con respecto al jugador
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3f; // Tiempo de suavizado

    private void Update()
    {
        // Calcula la posici�n deseada de la c�mara
        Vector3 desiredPosition = target.position + offset;

        // Interpola suavemente la posici�n de la c�mara hacia la posici�n deseada
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}
