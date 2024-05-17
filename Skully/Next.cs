using System.Collections;
using UnityEngine;

public class Next : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject levelFinishedUI;

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
        levelFinishedUI.SetActive(true);
        isPaused = !isPaused;
        Time.timeScale = 0f;
        isPaused = true;
    }
}
