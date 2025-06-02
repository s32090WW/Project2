using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int collectibleCount = 0;
   // public string collectibleText;

    public void AddCollectible()
    {
        collectibleCount++;
        Debug.Log("Collected: " + collectibleCount);
        
        //if (collectibleText != null)
         //   collectibleText.text = "Collectibles: " + collectibleCount;
    }
}
