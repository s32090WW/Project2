using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        Inventory playerInventory = collision.gameObject.GetComponent<Inventory>();

        if (playerInventory != null)
        {
            playerInventory.AddCollectible(); 
        }

        Destroy(gameObject);
    }
}