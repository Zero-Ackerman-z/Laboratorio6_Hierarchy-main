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

        //  rotación en los ejes X e Y
        rotationX += verticalInput * rotationSpeed;
        rotationY += horizontalInput * rotationSpeed;

        // Limite de  la rotación en el eje X y evitar giros excesivos
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        // Aplica la rotación al objeto del jugador
        transform.rotation = Quaternion.Euler(-rotationX, rotationY, 0);

        //  dirección de movimiento basada en la rotación
        Vector3 moveDirection = transform.forward;

        // movimiento solo hacia adelante
        if (moveDirection.z < 0)
        {
            moveDirection.z = 0;
        }

        // Normaliza la dirección del movimiento y aplica la velocidad
        moveDirection.Normalize();
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}

