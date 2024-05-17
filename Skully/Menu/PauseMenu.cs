using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Référence au panneau du menu options
    public GameObject[] HUDElements; // Tableau des éléments du HUD à cacher

    private bool isPaused = false; // Variable pour suivre l'état du jeu (en pause ou non)

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
            {
                ClosePause();
            }
            else
            {
                OpenPause();
            }
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button7))
        {
            if (pauseMenuUI.activeSelf)
            {
                ClosePause();
            }
            else
            {
                OpenPause();
            }
        }
    }

    public void OpenPause()
    {
        //Bascule l'état de pause
        isPaused = !isPaused;

        // Affichez le menu settings
        pauseMenuUI.SetActive(true);

        // Cachez les éléments du HUD
        foreach (GameObject element in HUDElements)
        {
            element.SetActive(false);
        }

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ClosePause()
    {
        // Cachez le menu settings
        pauseMenuUI.SetActive(false);

        // Affichez les éléments du HUD
        foreach (GameObject element in HUDElements)
        {
            element.SetActive(true);
        }

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
