using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEatworm : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 2f;

    public int currentPointIndex = 0;
    public Transform currentTarget;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentTarget = patrolPoints[currentPointIndex];
    }

    private void FixedUpdate()
    {
        Patrol();
    }

    public void Patrol()
    {
        Vector2 direction = (currentTarget.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            SetNextPatrolPoint();
        }
    }

    void SetNextPatrolPoint()
    {
        currentPointIndex++;

        if (currentPointIndex >= patrolPoints.Length)
        {
            currentPointIndex = 0;
        }

        currentTarget = patrolPoints[currentPointIndex];
    }
}
