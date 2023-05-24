using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
 public Transform[] patrolPoints;
    public float moveSpeed = 2f;

    public int currentPointIndex = 0;
    public Transform currentTarget;

    public void Start()
    {
        SetNextPatrolPoint();
    }

    private void Update()
    {
      
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);


        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            SetNextPatrolPoint();
        }
    }

    public void SetNextPatrolPoint()
    {
 
        currentTarget = patrolPoints[currentPointIndex];


        currentPointIndex++;

 
        if (currentPointIndex >= patrolPoints.Length)
        {
            currentPointIndex = 0;
        }
    }
}
