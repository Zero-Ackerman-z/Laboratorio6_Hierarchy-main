using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 2.0f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //  rotaci�n en los ejes X e Y
        rotationX += verticalInput * rotationSpeed;
        rotationY += horizontalInput * rotationSpeed;

        // Limite de  la rotaci�n en el eje X y evitar giros excesivos
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        // Aplica la rotaci�n al objeto del jugador
        transform.rotation = Quaternion.Euler(-rotationX, rotationY, 0);

        //  direcci�n de movimiento basada en la rotaci�n
        Vector3 moveDirection = transform.forward;

        // movimiento solo hacia adelante
        if (moveDirection.z < 0)
        {
            moveDirection.z = 0;
        }

        // Normaliza la direcci�n del movimiento y aplica la velocidad
        moveDirection.Normalize();
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}

