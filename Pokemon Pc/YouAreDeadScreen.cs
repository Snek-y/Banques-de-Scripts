using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class YouAreDeadScreen : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene("Game");

        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
