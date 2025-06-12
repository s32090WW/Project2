using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [SerializeField]private float maxHealth = 3;
    [SerializeField] private float health = 3;
    public Animator anim;



    public bool isDead = false;

    //licznik zycia
    //public int lives = 3;
    public TextMeshProUGUI livesText;


    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);

        
            //lives--;
            UpdateLivesUI();

            if (health <= 0)
            {
                isDead = true;

                anim.SetTrigger("IsDead");
                Debug.Log("Game Over");
            }
            //else
            //{
            //    health = maxHealth;
            //    Debug.Log("Player respawned with remaining lives.");
            //}
        
    }
    void Start()
    {
        UpdateLivesUI();
        anim = GetComponent<Animator>();
    }
    private void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + health;
    }
    void Update()
    {
        if (transform.position.y < -10f && !isDead) // dead zone dla gracza
        {
            TakeDamage(maxHealth);
        }
    }

    //health_counter ui
    //collectible counter ui

}
