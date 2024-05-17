using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManagerB : MonoBehaviour
{
    public Vector3 respawnPointB;

    private void Awake()
    {
        respawnPointB = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}