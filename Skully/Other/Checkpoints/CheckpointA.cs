using UnityEngine;

public class CheckpointA : MonoBehaviour
{
    public RespawnManagerA respawnManagerA;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            respawnManagerA.respawnPointA = transform.position;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}