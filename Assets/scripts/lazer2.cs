using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer2 : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento
    public float moveDistance = 3f; // Distancia de movimiento
    public float fadeDuration = 1f; // Duración del fade in/out

    private SpriteRenderer spriteRenderer;
    private Vector3 startingPosition;
    private bool movingDown = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startingPosition = transform.position;
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        if (movingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPosition - new Vector3(0, moveDistance, 0), moveSpeed * Time.deltaTime);

            if (transform.position.y <= startingPosition.y - moveDistance)
            {
                movingDown = false;
                StartCoroutine(FadeOut());
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, moveSpeed * Time.deltaTime);

            if (transform.position.y >= startingPosition.y)
            {
                movingDown = true;
                StartCoroutine(FadeIn());
            }
        }
    }

    private IEnumerator FadeIn()
    {
        Color color = spriteRenderer.color;
        color.a = 0; // Comienza totalmente transparente
        spriteRenderer.color = color;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            color.a = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            spriteRenderer.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = 1; // Asegúrate de que el color final sea totalmente opaco
        spriteRenderer.color = color;
    }

    private IEnumerator FadeOut()
    {
        Color color = spriteRenderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            color.a = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            spriteRenderer.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = 0; // Asegúrate de que el color final sea totalmente transparente
        spriteRenderer.color = color;
    }
}
