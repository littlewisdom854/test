using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;

    public HealthBar healthBar;


 

    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    public void TakeDamage (int damage )
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth<= 0 )
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("die");
    }
}
