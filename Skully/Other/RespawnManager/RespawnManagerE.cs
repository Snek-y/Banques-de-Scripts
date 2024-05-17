using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManagerE : MonoBehaviour
{
    public Vector3 respawnPointE;

    private void Awake()
    {
        respawnPointE = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}