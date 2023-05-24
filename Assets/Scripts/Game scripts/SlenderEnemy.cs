using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlenderEnemy : MonoBehaviour
{
    public PlayerHealth playerHealth;
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          playerHealth.TakeDamage(20);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
