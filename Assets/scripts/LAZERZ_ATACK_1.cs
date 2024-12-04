using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections; // Necesario para usar coroutines

public class LAZERZ_ATACK_1 : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
    public float velocidad = 3f; // Velocidad de persecución
    public float distanciaPersecucion = 5f; // Distancia máxima para comenzar a perseguir
    private bool puedePerseguir = false; // Controla si puede perseguir al jugador

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(EsperarParaPerseguir());
    }

    void Update()
    {
        if (puedePerseguir && jugador != null)
        {
            // Calcular la distancia al jugador
            float distancia = Vector2.Distance(transform.position, jugador.position);

            // Solo perseguir si el jugador está dentro de la distancia de persecución
            if (distancia < distanciaPersecucion)
            {
                Vector2 direccion = (jugador.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);

                // Rotar el enemigo hacia el jugador
                float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo - 90));
            }
        }
    }

    private IEnumerator EsperarParaPerseguir()
    {
        yield return new WaitForSeconds(0f); // Cambia 2f por 21f si deseas esperar 21 segundos
        puedePerseguir = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PerderVida();
        }
    }

}
