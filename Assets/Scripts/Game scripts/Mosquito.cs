using UnityEngine;

public class Mosquito : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float hitForce = 10f;
    public float hitCooldown = 2f;
    public PlayerHealth playerHealth;

    private Transform player;
    private Rigidbody2D rb;
    private bool isOnCooldown;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isOnCooldown)
        {
            // Fly towards the player
            Vector2 direction = player.position - transform.position;
            rb.velocity = direction.normalized * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isOnCooldown)
            {
                // Apply slight hit force to the player
                Vector2 direction = collision.transform.position - transform.position;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * hitForce, ForceMode2D.Impulse);
                playerHealth.TakeDamage(1);

                StartCooldown();
            }
        }
    }

    private void StartCooldown()
    {
        isOnCooldown = true;
        Invoke(nameof(ResetCooldown), hitCooldown);
    }

    private void ResetCooldown()
    {
        isOnCooldown = false;
    }
}
