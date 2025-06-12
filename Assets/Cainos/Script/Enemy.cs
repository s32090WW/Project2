using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float damage = 1f;
    public float patrolSpeed = 2f;
    public Transform leftLimit;
    public Transform rightLimit;

    private bool movingRight = true;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (movingRight)
        {
            rb.velocity = new Vector2(patrolSpeed, rb.velocity.y);
            if (transform.position.x >= rightLimit.position.x)
            {
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(-patrolSpeed, rb.velocity.y);
            if (transform.position.x <= leftLimit.position.x)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        Player_Health health = collision.GetComponent<Player_Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
            anim?.SetTrigger("Attack"); // tu ma byc animacja
        }
    }
}