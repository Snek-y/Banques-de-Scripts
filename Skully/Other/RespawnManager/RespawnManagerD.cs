using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManagerD : MonoBehaviour
{
    public Vector3 respawnPointD;

    private void Awake()
    {
        respawnPointD = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}