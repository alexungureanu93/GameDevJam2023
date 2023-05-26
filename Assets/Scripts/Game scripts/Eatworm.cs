using UnityEngine;
using System.Collections;

public class Eatworm : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float chaseRange = 5f;
    public float attackDelay = 1f;

    private Transform player;
    private Vector3 startingPosition;
    private bool isChasing = false;
    private bool isAttacking = false;
    private bool isPatrolling = false;

    public PlayerHealth playerHealth;
    public PatrolEatworm patrolEatworm;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startingPosition = transform.position;
        patrolEatworm = GetComponent<PatrolEatworm>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            isChasing = true;
            isAttacking = false;
            StopPatrol();
        }
        else if (distanceToPlayer > chaseRange + 1f)
        {
            isChasing = false;
            isAttacking = false;
            StartPatrol();
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else if (isPatrolling)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        patrolEatworm.Patrol();
    }

    private void ChasePlayer()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        rb.velocity = direction.normalized * chaseSpeed;

        if (!isAttacking)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        // animation

        yield return new WaitForSeconds(attackDelay);

        playerHealth.TakeDamage(5);

        yield return new WaitForSeconds(attackDelay);

        isAttacking = false;
    }

    public void StartPatrol()
    {
        isPatrolling = true;
        rb.velocity = Vector2.zero;
    }

    public void StopPatrol()
    {
        isPatrolling = false;
        rb.velocity = Vector2.zero;
    }
}
