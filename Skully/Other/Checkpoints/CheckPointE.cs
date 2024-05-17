using UnityEngine;

public class CheckpointE : MonoBehaviour
{
    public RespawnManagerE respawnManagerE;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            respawnManagerE.respawnPointE = transform.position;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}