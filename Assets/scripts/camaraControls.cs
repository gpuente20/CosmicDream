using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraControls : MonoBehaviour
{
public float velocidadDesplazamiento = 5f; // Velocidad de desplazamiento de la c�mara
    public float limiteYSuperior = 10f; // L�mite superior de la c�mara

    private void Update()
    {
        MoverCamara();
    }

    private void MoverCamara()
    {
        // Obtener la posici�n actual de la c�mara
        Vector3 posicionCamara = transform.position;

        // Calcular la nueva posici�n vertical de la c�mara
        float nuevaPositionY = posicionCamara.y + (velocidadDesplazamiento * Time.deltaTime);

        // Asegurarse de que la c�mara no se mueva m�s all� del l�mite superior
        if (nuevaPositionY <= limiteYSuperior)
        {
            // Actualizar la posici�n de la c�mara
            transform.position = new Vector3(posicionCamara.x, nuevaPositionY, posicionCamara.z);
        }
    }
}
