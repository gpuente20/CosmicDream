using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController_LBF : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador

    private Rigidbody2D rb; // Referencia al componente Rigidbody2D
    private Vector2 movement; // Vector para almacenar el movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D
    }

    void Update()
    {
        // Capturar la entrada del jugador
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Mover el jugador
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar colisiones con otros objetos
        if (collision.gameObject.CompareTag("Suelo")) // Cambia "Obstacle" por la etiqueta que quieras usar
        {
            Debug.Log("Colisionó con: " + collision.gameObject.name);
            // Aquí puedes agregar acciones adicionales, como detener el movimiento o reducir la velocidad
        }
    }
}
