using UnityEngine;

public class CheckpointD : MonoBehaviour
{
    public RespawnManagerD respawnManagerD;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            respawnManagerD.respawnPointD = transform.position;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}