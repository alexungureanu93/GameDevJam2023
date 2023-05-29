using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
    public int health;
    public int maxHealth;

    private bool canTakeDamage = true;
    private float damageCooldown = 0.5f;
    public CharacterController2D Character;
    public AudioSource HitSound;

  private void Start()
    {
        slider.maxValue = maxHealth;
        slider.value = Health.Instance.PLAYER_HP;
        health = Health.Instance.PLAYER_HP;
  }

    private void Update()
    {
        slider.value = health;
        if (health <= 0)
        {
         Character.Die();
        }
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {

            HitSound.Play();
            health -= damage;
            Health.Instance.PLAYER_HP = health;
            StartCoroutine(StartDamageCooldown());
        }
    }

    private IEnumerator StartDamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }


}