using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float fireRange; // Set this in the editor to specify the fire range
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float shootingRate;
    private Transform target;
    private float shootingTimer;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            target = playerObject.transform;

        shootingTimer = 0f;
    }

    void Update()
    {
        // Check if the target reference is null before proceeding
        if (target == null)
            return;

        float distance = Vector2.Distance(transform.position, target.position);

        // Move towards the player if the distance is greater than the fire range
        if (distance > fireRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        // Make the enemy face the player at all times
        transform.up = target.position - transform.position;

        // Shoot a projectile towards the player at the specified rate
        shootingTimer += Time.deltaTime;
        if (shootingTimer >= shootingRate)
        {
            shootingTimer = 0f;
            InstantiateProjectile();
        }
    }

    void InstantiateProjectile()
    {
        // Check if the target reference is null before proceeding
        if (target == null)
            return;

        // Instantiate the projectile at the spawn point
        GameObject projectile =
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        // Set the projectile's velocity towards the player
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = (target.position - projectile.transform.position).normalized;
    }
}