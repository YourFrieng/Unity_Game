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
    IEnumerator Interact()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
        i++;
        i %= 2;
        yield break;
    }
    void Update()
    {
        if (interactionAllowed)
        {
            Debug.Log("Press E"); //TODO: make sprite what write msg on screen
        }
        if (interactionAllowed && Input.GetKeyDown(KeyCode.E))
        {
                StartCoroutine(Interact()); 
        }
    }
}
