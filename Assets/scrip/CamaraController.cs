using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    [SerializeField] Transform target; // El objeto que la cámara seguirá
    public Vector3 offset = new Vector3(0, 5, -10); // Offset de la cámara con respecto al jugador
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3f; // Tiempo de suavizado

    private void Update()
    {
        // Calcula la posición deseada de la cámara
        Vector3 desiredPosition = target.position + offset;

        // Interpola suavemente la posición de la cámara hacia la posición deseada
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}
