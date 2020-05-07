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
    void Start()
    {
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
                    break;
                case 1:
                    rb2d.velocity = new Vector2(moveSpeed, 0);
                    break;
                case 2:
                    rb2d.velocity = new Vector2(0, -moveSpeed);
                    break;
                case 3:
                    rb2d.velocity = new Vector2(-moveSpeed, 0);
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
    }
}
