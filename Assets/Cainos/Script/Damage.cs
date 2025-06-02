using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public float damage = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        Player_Health health = collision.gameObject.GetComponent<Player_Health>();

        if (health == null)
        {
            return;
        }

        health.TakeDamage(damage);
        
    }
}
