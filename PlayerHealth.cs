using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Maximum health the player can have
    public int maxHealth = 100;

    // Current health of the player
    public int health;

    private void Start()
    {
        // Set the player's health to the maximum value
        health = maxHealth;
    }

    // Function to take damage
    public void TakeDamage(int damage)
    {
        // Subtract damage from health
        health -= damage;

        // If the player's health is 0 or below, trigger the "Die" animation (if attached) and destroy the game object
        if (health <= 0)
        {
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("Die");
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}