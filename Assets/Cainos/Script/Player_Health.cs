using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [SerializeField]private float maxHealth = 3;
    [SerializeField] private float health = 3;

    public bool isDead = false;

    //licznik zycia
    public int lives = 3;
    public TextMeshProUGUI livesText;


    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);

        if (health == 0)
        {
            lives--;
            UpdateLivesUI();

            if (lives <= 0)
            {
                isDead = true;
               
                Debug.Log("Game Over");
            }
            else
            {
                health = maxHealth;
                Debug.Log("Player respawned with remaining lives.");
            }
        }
    }
    void Start()
    {
        UpdateLivesUI();
    }
    private void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }

    //health_counter ui
    //collectible counter ui

}
