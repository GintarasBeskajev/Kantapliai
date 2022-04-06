using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character2DParkour : MonoBehaviour
{
    Rigidbody2D rigBody;
    public float jumpSpeed = 10f;
    public float movementSpeed = 10f;
    [SerializeField] private float maxJumpCount = 1f;
    public float Health = 100f;
    private float currentJumps = 0f;
    bool isGrounded;
    float horizontal;

    void Start()
    {
        isGrounded = true;
        rigBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(Health <= 0)
        {
            SceneManager.LoadScene("Hub");
        }

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
        if (Input.GetButtonDown("Jump") && isGrounded || Input.GetButtonDown("Jump") && currentJumps < maxJumpCount)
        {
            rigBody.velocity = Vector2.zero;
            rigBody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            isGrounded = false;
            currentJumps++;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && isGrounded == false)
        {
            isGrounded = true;
            currentJumps = 0f;
        }

        if (other.gameObject.tag == "Lava")
        {
            Health = Health - 20;
            transform.position = new Vector3(-8, -4, 0);
        }
    }
}