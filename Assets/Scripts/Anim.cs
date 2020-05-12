using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    private Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            
            anim.SetBool("isUp", true);
            anim.SetBool("isDown", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isDown", true);
            anim.SetBool("isUp", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isLeft", true);
            anim.SetBool("isUp", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isDown", false);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRight", true);
            anim.SetBool("isDown", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isLeft", false);

        }

        if (moveInput.x == 0 && moveInput.y == 0)
        {
            anim.SetInteger("speed", 0);

            
        }
        else
        {
            anim.SetInteger("speed", 1);
           
        }
        

    }
}