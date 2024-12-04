using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float velocidad = 5f;       // Velocidad de movimiento
    public float fuerzaSalto = 10f;    // Fuerza del salto
    private Rigidbody2D rb;             // Componente Rigidbody2D
    private bool enSuelo;               // Para verificar si el jugador está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D
    }

    void Update()
    {
        Movimiento();                     // Llamar a la función de movimiento

        if (Input.GetButtonDown("Jump") && enSuelo) // Comprobar si se presiona el botón de salto
        {
            Saltar();
        }
    }

    void Movimiento()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal"); // Obtener la entrada horizontal
        rb.velocity = new Vector2(movimientoHorizontal * velocidad, rb.velocity.y); // Mover el jugador
    }

    void Saltar()
    {
        rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto); // Aplicar fuerza de salto
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo")) // Comprobar colisión con el suelo
        {
            enSuelo = true; // El jugador está en el suelo
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo")) // Verificar si el jugador sale del suelo
        {
            enSuelo = false; // El jugador no está en el suelo
        }
    }
} 

