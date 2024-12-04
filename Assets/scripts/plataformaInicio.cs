using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaInicio : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    public float delay = 1f; // Tiempo de delay en segundos

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * velocidad);
    }
}

