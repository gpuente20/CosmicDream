using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraControls : MonoBehaviour
{
public float velocidadDesplazamiento = 5f; // Velocidad de desplazamiento de la cámara
    public float limiteYSuperior = 10f; // Límite superior de la cámara

    private void Update()
    {
        MoverCamara();
    }

    private void MoverCamara()
    {
        // Obtener la posición actual de la cámara
        Vector3 posicionCamara = transform.position;

        // Calcular la nueva posición vertical de la cámara
        float nuevaPositionY = posicionCamara.y + (velocidadDesplazamiento * Time.deltaTime);

        // Asegurarse de que la cámara no se mueva más allá del límite superior
        if (nuevaPositionY <= limiteYSuperior)
        {
            // Actualizar la posición de la cámara
            transform.position = new Vector3(posicionCamara.x, nuevaPositionY, posicionCamara.z);
        }
    }
}
