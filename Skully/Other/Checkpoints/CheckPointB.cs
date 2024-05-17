using UnityEngine;

public class CheckpointB : MonoBehaviour
{
    public RespawnManagerB respawnManagerB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            respawnManagerB.respawnPointB = transform.position;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}