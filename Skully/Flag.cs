using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    public string sceneName;
    private bool isPaused = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(Win());
        }
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
        isPaused = !isPaused;
        Time.timeScale = 0f;
        isPaused = true;
    }
}
