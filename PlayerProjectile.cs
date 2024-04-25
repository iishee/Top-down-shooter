using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioClip explosionSound;

    private bool hasRotated = false;

    void Update()
    {
        if (!hasRotated)
        {
            // Get the cursor position in world coordinates
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculate the angle between the missile and the cursor position
            float angle = Vector2.Angle(Vector2.right, cursorPosition - (Vector2) transform.position);

            // Rotate the missile towards the calculated angle
            if (cursorPosition.y < transform.position.y)
            {
                transform.rotation = Quaternion.Euler(0, 0, -angle - 90f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
            }

            hasRotated = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If we collide with the enemy, get a reference to the EnemyHealth script and call the TakeDamage function, then instantiate the explosion prefab and play the explosion sound
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(1); // Take 1 point of damage
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Instantiate the explosion prefab
            AudioSource.PlayClipAtPoint(explosionSound, transform.position); // Play the explosion sound
            Destroy(gameObject); // Destroy the projectile game object
            Destroy(explosion, 0.1f); // Destroy the explosion game object after 0.1 seconds
        }

        // If we collide with an enemy projectile, destroy both projectiles and instantiate the explosion prefab
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Instantiate the explosion prefab
            AudioSource.PlayClipAtPoint(explosionSound, transform.position); // Play the explosion sound
            Destroy(other.gameObject);
            Destroy(gameObject); // Destroy the projectile game object
            Destroy(explosion, 0.1f); // Destroy the explosion game object after 0.1 seconds
        }
    }
}