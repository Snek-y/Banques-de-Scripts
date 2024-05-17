using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManagerC : MonoBehaviour
{
    public Vector3 respawnPointC;

    private void Awake()
    {
        respawnPointC = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}