using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas
public class BtnJUGAR : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referencia al menú de pausa

    private bool isPaused = false;

    void Update()
    {
        // Pausar el juego al presionar la tecla "Esc"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Ocultar el menú de pausa
        Time.timeScale = 1f; // Reanudar el juego
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Mostrar el menú de pausa
        Time.timeScale = 0f; // Pausar el juego
        isPaused = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1_LTMK"); // Cambia por el nombre de tu escena
    }

}
