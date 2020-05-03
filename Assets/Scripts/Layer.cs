using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    void Awake()//used for static objects
    {
        setPosition();
    }
   void Update()
    {
        setPosition();
    }
    void setPosition()
    {
        GetComponent<SpriteRenderer>().sortingOrder = (int)transform.position.y * -1;
    }
}
