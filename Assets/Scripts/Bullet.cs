using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    public PlayerHealth health;
    private Rigidbody2D myRb;
    private float force =10f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        myRb=GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        myRb.velocity = new Vector2 (direction.x, direction.y).normalized *force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) *Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10) 
        { 
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            health.TakeDamage(20);
            Destroy(gameObject);
        }

    }
}

