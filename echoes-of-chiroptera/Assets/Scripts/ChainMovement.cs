using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isChain;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;
    
    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isChain && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chain"))
        {
            isChain = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Chain"))
        {
            isChain = false;
            isClimbing = false;
        }
    }
}
