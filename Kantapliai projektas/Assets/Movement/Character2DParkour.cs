using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DParkour : MonoBehaviour
{
    Rigidbody2D rigBody;
    public float jumpSpeed = 10f;
    public float movementSpeed = 10f;
    bool isGrounded;
    float horizontal;

    void Start()
    {
        isGrounded = true;
        rigBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 vel = rigBody.velocity;
        vel.x = horizontal * movementSpeed;
        rigBody.velocity = vel;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigBody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && isGrounded == false)
        {
            isGrounded = true;
        }
    }
}