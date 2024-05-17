using System.Collections;
using UnityEngine;

public class Next : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject levelFinishedUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Win());
        }
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(0);
        levelFinishedUI.SetActive(true);
        isPaused = !isPaused;
        Time.timeScale = 0f;
        isPaused = true;
    }
}
