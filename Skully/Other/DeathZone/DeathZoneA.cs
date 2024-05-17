using System.Collections;
using UnityEngine;

public class DeathZoneA : MonoBehaviour
{
    public RespawnManagerA respawnManagerA;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(2);
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        yield return new WaitForSeconds(0.2f);
        collision.transform.position = respawnManagerA.respawnPointA;
    }
}