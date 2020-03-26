using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    int i = 1;
    public Sprite[] sprites = new Sprite[2];
    private bool interactionAllowed;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            interactionAllowed = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            interactionAllowed = false;
        }
    }
    void Interact()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
        i++;
        i %= 2;
    }
    void Update()
    {
        if (interactionAllowed && Input.GetKey(KeyCode.E)){
            Interact();
        }
    }
}
