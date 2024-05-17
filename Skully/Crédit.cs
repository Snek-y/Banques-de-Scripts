using UnityEngine;
using UnityEngine.SceneManagement;

public class Crédit : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }
}
