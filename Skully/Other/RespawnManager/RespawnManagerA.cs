using UnityEngine;

public class RespawnManagerA : MonoBehaviour
{
    public Vector3 respawnPointA;

    private void Awake()
    {
        respawnPointA = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
