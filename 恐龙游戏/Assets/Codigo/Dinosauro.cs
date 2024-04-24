using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donosauro : MonoBehaviour
{
    Rigidbody2D rb;
    public float jump;
    bool isJumping;
    public GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isJumping == false)
        {
            rb.velocity = new Vector2(0, jump);
            isJumping = true;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;

        if (collision.gameObject.tag== "Cactus")
        {
            gm.GameOver();
        }

    }
}

