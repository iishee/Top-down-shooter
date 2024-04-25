using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Maximum health the enemy can have
    public int maxHealth = 100;
    // Current health of the enemy
    public int health;

    private void Start()
    {
        // Set the enemy's health to the maximum value
        health = maxHealth;
    }

// Function to take damage
    public void TakeDamage(int damage)
    {
        // Subtract damage from health
        health -= damage;

        // If the enemy's health is 0 or below, destroy the game object
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
