 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parlax : MonoBehaviour
{
    private float length, startPosition;
    public GameObject Camera;
    public float ParallaxEffect;
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }
    void Update()
    {
        float temp = (Camera.transform.position.x * (1 - ParallaxEffect));
        float distance = (Camera.transform.position.x * ParallaxEffect);
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
       if(temp> startPosition + length) { startPosition += length; }
       else if(temp < startPosition - length) { startPosition -= length;}
    }
}
