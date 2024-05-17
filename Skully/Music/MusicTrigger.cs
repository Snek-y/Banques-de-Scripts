using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField] AudioSource forest;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            forest.Play();
        }
    }
}