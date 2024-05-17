using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        Time.timeScale = 1f;
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            LoadMainMenu();
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            LoadMainMenu();
        }
    }
}