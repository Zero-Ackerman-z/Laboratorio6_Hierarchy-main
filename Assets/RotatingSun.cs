using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSun : MonoBehaviour
{
    public float rotationSpeed = 10.0f; // Velocidad de rotación del Sol en grados por segundo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

    }
}
