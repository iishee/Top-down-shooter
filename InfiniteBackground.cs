using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    // The speed at which the background scrolls
    public float scrollSpeed = 0.5f;
    // The width of the background sprite
    private float spriteWidth;
    // The position of the background sprite
    private Vector2 startPos;
    // The second copy of the background sprite
    private GameObject spriteCopy;

    void Start()
    {
        // Get the width of the background sprite
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        // Get the starting position of the background sprite
        startPos = transform.position;
        // Create a second copy of the background sprite
        spriteCopy = Instantiate(gameObject, startPos + Vector2.right * spriteWidth, Quaternion.identity);
    }

    void Update()
    {
        // Calculate the new position of the background sprite
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, spriteWidth);
        // Set the position of the background sprite
        transform.position = startPos + Vector2.left * newPos;
        spriteCopy.transform.position = startPos + Vector2.right * (spriteWidth - newPos);

        // If the background sprite goes off the left side of the screen, reset its position to the right side
        if (transform.position.x < -spriteWidth)
        {
            transform.position = startPos + Vector2.right * spriteWidth;
        }
        // If the second copy of the background sprite goes off the right side of the screen, reset its position to the left side
        if (spriteCopy.transform.position.x > spriteWidth)
        {
            spriteCopy.transform.position = startPos + Vector2.left * spriteWidth;
        }
    }
}