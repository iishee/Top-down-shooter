using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewProjectile : MonoBehaviour
{
    public float speed = 5;
    public GameObject explosionPrefab;
    public AudioClip explosionSound;
    private Transform player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            player = playerObject.transform;
    }

    void Update()
    {
        // Check if player reference is null before accessing its position
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.up = player.position - transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If we collide with the player, get a reference to the PlayerHealth script and call the TakeDamage function, then instantiate the explosion prefab and play the explosion sound
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
                playerHealth.TakeDamage(1);  // Take 1 point of damage
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);  // Instantiate the explosion prefab
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);  // Play the explosion sound
            Destroy(gameObject);  // Destroy the projectile game object
            Destroy(explosion, 0.1f);  // Destroy the explosion game object after 0.1 seconds
        }
    }
}