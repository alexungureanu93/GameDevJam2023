using UnityEngine;
using System.Collections;

public class Nightmare : MonoBehaviour
{
    public float moveSpeed = 3f;
    public int attackCount = 3;
    public float attackCooldown = 2f;
    public PlayerHealth playerHealth;

    private Transform player;
    private bool isAttacking;
    private bool isOnCooldown;
    private int currentAttackCount;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentAttackCount = attackCount;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isAttacking && !isOnCooldown)
        {
            // Move towards the player
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
            if (!isAttacking && !isOnCooldown)
            {
                // Start attacking
                StartAttacking();
            }
        }
    }

    private void StartAttacking()
    {
        isAttacking = true;
        currentAttackCount--;

        playerHealth.TakeDamage(5);

        if (currentAttackCount <= 0)
        {
            StartCooldown();
        }
        else
        {
            isAttacking = false;
        }
    }

    private void StartCooldown()
    {
        isOnCooldown = true;
        currentAttackCount = attackCount;

        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);

        // Cooldown finished, resume movement towards the player
        isAttacking = false;
        isOnCooldown = false;
    }
}
