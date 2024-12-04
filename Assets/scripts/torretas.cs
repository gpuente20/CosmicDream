using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torretas : MonoBehaviour
{
    public float tiempoMoviemiento = 0.3f;
    public float velocidad = 2.0f; // Velocidad de movimiento
    public float distanciaMaxima = 5.0f; // Distancia m�xima antes de regresar


    private Vector3 posicionInicial; // Posici�n inicial del objeto
    private bool moviendoDerecha = true; // Direcci�n del movimiento
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Mueve el objeto
        if (moviendoDerecha)
        {
            transform.position += Vector3.right * velocidad * Time.deltaTime;

            // Verifica si ha alcanzado la distancia m�xima
            if (transform.position.x >= posicionInicial.x + distanciaMaxima)
            {
                moviendoDerecha = false; // Cambia la direcci�n
            }
        }
        else
        {
            transform.position -= Vector3.right * velocidad * Time.deltaTime;

            // Verifica si ha regresado a la posici�n inicial
            if (transform.position.x <= posicionInicial.x)
            {
                moviendoDerecha = true; // Cambia la direcci�n
            }
        }
    }
}
