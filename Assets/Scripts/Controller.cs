using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public int level;
    private Rigidbody2D rb2d;
    private Vector2 moveVelocity;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     
    }
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = speed * moveInput;
    }
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveVelocity * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "NextLevel")
        {
            SceneManager.LoadScene(level);
        }
    }
}

