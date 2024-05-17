using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneB : MonoBehaviour
{
    public RespawnManagerB respawnManagerB;

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
        collision.transform.position = respawnManagerB.respawnPointB;
    }
}
