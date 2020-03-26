using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public int distance = -10;
    public float lift = 1.5f;
    float startSize;
    void Update()
    {
        transform.position = new Vector3(0, lift, distance) + player.position;
        transform.LookAt(player);

    }
}
