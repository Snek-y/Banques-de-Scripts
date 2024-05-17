using UnityEngine;

public class CheckpointC : MonoBehaviour
{
    public RespawnManagerC respawnManagerC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            respawnManagerC.respawnPointC = transform.position;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}