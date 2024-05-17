using UnityEngine;
using UnityEngine.SceneManagement;

public class Crédit : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }
}
