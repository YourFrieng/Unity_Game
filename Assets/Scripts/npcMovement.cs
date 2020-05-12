using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb2d;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;

    public float waitTime;
    private float waitCounter;

    private int walkDirection;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        walkCounter = walkTime;
        waitCounter = waitTime;
        ChooseDirection();
    }

    void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            switch (walkDirection)
            {
                case 0:
                    rb2d.velocity = new Vector2(0, moveSpeed);
                    anim.SetBool("isForward", true);
                    anim.SetBool("isBack", false);
                    anim.SetBool("isLeft", false);
                    anim.SetBool("isRight", false);
                    break;
                case 1:
                    rb2d.velocity = new Vector2(moveSpeed, 0);
                    anim.SetBool("isBack", true);
                    anim.SetBool("isForward", false);
                    anim.SetBool("isLeft", false);
                    anim.SetBool("isRight", false);
                    break;
                case 2:
                    rb2d.velocity = new Vector2(0, -moveSpeed);
                    anim.SetBool("isLeft", true);
                    anim.SetBool("isForward", false);
                    anim.SetBool("isRight", false);
                    anim.SetBool("isBack", false);
                    break;
                case 3:
                    rb2d.velocity = new Vector2(-moveSpeed, 0);
                    anim.SetBool("isRight", true);
                    anim.SetBool("isBack", false);
                    anim.SetBool("isForward", false);
                    anim.SetBool("isLeft", false);
                    break;
            }
            if (walkCounter < 0)
            {
                waitCounter = waitTime;
                isWalking = false;
                anim.speed = 0;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            rb2d.velocity = Vector2.zero;
            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }
    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
        anim.speed = 1;

    }
}
