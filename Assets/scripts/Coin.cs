using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource audioSource;

    public int valor = 1;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play(); // Reproducir el sonido

            gameManager.SumarPuntos(valor);
            Destroy(this.gameObject);
        }

    }
}
