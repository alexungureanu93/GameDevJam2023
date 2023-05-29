using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : MonoBehaviour
{
    public PlayerHealth health;
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    public int hp = 1;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance= Vector2.Distance(transform.position,player.transform.position);
        if (distance < 8)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Instantiate(bullet,bulletPos.position,Quaternion.identity);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(20);
        }

    }
}
