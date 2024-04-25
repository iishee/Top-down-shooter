using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    // Projectile prefab
    public GameObject projectilePrefab;

    // Reference to the Rigidbody2D component
    private Rigidbody2D rb;

    // Speed at which the player will move
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from WASD keys and move the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        rb.velocity = movement * speed;

        // Rotate the sprite to face the cursor
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, cursorPos - transform.position);

        // Check if the player has pressed the fire button
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the projectile prefab at the position of the player
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Get a reference to the Rigidbody2D component of the projectile
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

            // Apply a force to the projectile in the direction the player is facing
            Vector2 projectileForce = transform.up * 10f;
            projectileRb.AddForce(projectileForce, ForceMode2D.Impulse);
        }
    }
}