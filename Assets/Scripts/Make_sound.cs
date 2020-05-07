using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_sound : MonoBehaviour
{
    AudioSource myTrack;
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
        if (col.tag == "Player")
        {
            interactionAllowed = false;
        }
    }
    void Start()
    {
        myTrack = GetComponent<AudioSource>();
    }

        // Update is called once per frame
        void Update()
    {
        if (interactionAllowed && Input.GetKeyDown(KeyCode.E))
        {
            myTrack.Play();
        }
    }
}
