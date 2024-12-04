using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public float tiempoMoviemiento = 0.3f;
    public float velocidad = 2.0f; // Velocidad de movimiento
    public float distanciaMaxima = 5.0f; // Distancia máxima antes de regresar
    public float velocidadArriba = 0.5f;

    private Vector3 posicionInicial; // Posición inicial del objeto
    private bool moviendoDerecha = true; // Dirección del movimiento

    public float delay = 10f;

    private Vector3 startingPosition;
    private bool movingDown = true;
    public float moveSpeed = 2f; // Velocidad de movimiento
    public float moveDistance = 3f; // Distancia de movimiento


    void Start()
    {
        posicionInicial = transform.position;
        Invoke("atacarJugador", delay);
    }

    void Update()
    {
        MoverHaciaArriba();

        // Mueve el objeto
        if (moviendoDerecha)
        {
            transform.position += Vector3.right * velocidad * Time.deltaTime;

            // Verifica si ha alcanzado la distancia máxima
            if (transform.position.x >= posicionInicial.x + distanciaMaxima)
            {
                moviendoDerecha = false; // Cambia la dirección
            }
        }
        else
        {
            transform.position -= Vector3.right * velocidad * Time.deltaTime;

            // Verifica si ha regresado a la posición inicial
            if (transform.position.x <= posicionInicial.x)
            {
                moviendoDerecha = true; // Cambia la dirección
            }
        }
    }
    void atacarJugador()
    {
        if (movingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPosition - new Vector3(0, moveDistance, 0), moveSpeed * Time.deltaTime);

            if (transform.position.y <= startingPosition.y - moveDistance)
            {
                movingDown = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, moveSpeed * Time.deltaTime);

            if (transform.position.y >= startingPosition.y)
            {
                movingDown = true;
            }
        }
    }

    private void MoverHaciaArriba()
    {
        // Obtener la posición actual del objeto
        Vector3 posicionActual = transform.position;

        // Calcular la nueva posición vertical del objeto
        float nuevaPositionY = posicionActual.y + (velocidadArriba * Time.deltaTime);

        // Actualizar la posición del objeto
        transform.position = new Vector3(posicionActual.x, nuevaPositionY, posicionActual.z);
    }
}
