using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class padScript : MonoBehaviour
{
    public float fuerzaExtraSalto = 15f; // Fuerza adicional para el salto

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) // Verifica si el objeto es el jugador
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, fuerzaExtraSalto); // Aplica la fuerza adicional
            }
        }
    }
}
