using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // The prefab of the enemy to instantiate
    public GameObject enemyPrefab;
    // The position of the top-right corner of the screen in world coordinates
    private Vector2 screenTopRight;
    // The position of the bottom-right corner of the screen in world coordinates
    private Vector2 screenBottomRight;
    // The width of the enemy prefab
    private float enemyWidth;
    // The height of the enemy prefab
    private float enemyHeight;
    // The scroll speed of the background
    public float scrollSpeed;
    // The width of the screen in world coordinates
    private float screenWidth;
    // The height of the screen in world coordinates
    private float screenHeight;

    void Start()
    {
        // Get the position of the top-right corner of the screen in world coordinates
        screenTopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        // Get the position of the bottom-right corner of the screen in world coordinates
        screenBottomRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        // Get the width of the enemy prefab
        enemyWidth = enemyPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        // Get the height of the enemy prefab
        enemyHeight = enemyPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
        // Get the width of the screen in world coordinates
        screenWidth = screenTopRight.x - screenBottomRight.x;
        // Get the height of the screen in world coordinates
        screenHeight = screenTopRight.y - screenBottomRight.y;

        // Start the SpawnEnemies
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        // Run the enemy spawning loop indefinitely
        while (true)
        {
            // Calculate the x position at which to instantiate the enemy
            float xPos = screenTopRight.x + enemyWidth / 2 + scrollSpeed * Time.deltaTime;
            // Instantiate an enemy at a random y position within the screen bounds
            float yPos = Random.Range(screenBottomRight.y + enemyHeight / 2, screenTopRight.y - enemyHeight / 2);
            GameObject enemy = Instantiate(enemyPrefab, new Vector2(xPos, yPos), Quaternion.identity);
            // Wait for a random amount of time before spawning the next enemy
            yield return new WaitForSeconds(Random.Range(1, 8));
        }
    }
}

