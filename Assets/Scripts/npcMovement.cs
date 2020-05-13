using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D rb2d;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;

    public float waitTime;
    private float waitCounter;

    private int walkDirection;
    public Collider2D WalkArea;
    private Animator anim;
    private bool hasWalkArea;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        walkCounter = walkTime;
        waitCounter = waitTime;
        ChooseDirection();
        if (WalkArea != null)
        {
            minWalkPoint = WalkArea.bounds.min;
            maxWalkPoint = WalkArea.bounds.max;
            hasWalkArea = true;
        }
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
                    anim.SetBool("isUp", true);
                    anim.SetBool("isDown", false);
                    anim.SetBool("isLeft", false);
                    anim.SetBool("isRight", false);
                    if(hasWalkArea && (transform.position.y > maxWalkPoint.y))
                    {
                        waitCounter = waitTime;
                        isWalking = false;
                    }
                    break;
                case 1:
                    rb2d.velocity = new Vector2(moveSpeed, 0);
                    anim.SetBool("isRight", true);
                    anim.SetBool("isDown", false);
                    anim.SetBool("isUp", false);
                    anim.SetBool("isLeft", false);
                    if (hasWalkArea && (transform.position.x > maxWalkPoint.x))
                    {
                        waitCounter = waitTime;
                        isWalking = false;
                    } 
                    break;
                case 2:
                    rb2d.velocity = new Vector2(0, -moveSpeed);
                    anim.SetBool("isDown", true);
                    anim.SetBool("isUp", false);
                    anim.SetBool("isLeft", false);
                    anim.SetBool("isRight", false);
                    if (hasWalkArea && (transform.position.y < minWalkPoint.y))
                    {
                        waitCounter = waitTime;
                        isWalking = false;
                    }
                    break;
                case 3:
                    rb2d.velocity = new Vector2(-moveSpeed, 0);
                    anim.SetBool("isLeft", true);
                    anim.SetBool("isUp", false);
                    anim.SetBool("isRight", false);
                    anim.SetBool("isDown", false);
                    if (hasWalkArea && (transform.position.x < minWalkPoint.x))
                    {
                        waitCounter = waitTime;
                        isWalking = false;
                    }
                    break;
            }
            if (walkCounter < 0)
            {
                waitCounter = waitTime;
                isWalking = false;
            }
        }
        else
        {
            anim.speed = 0;
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
