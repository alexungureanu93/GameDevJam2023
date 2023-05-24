using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    public int hp = 100;

    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;

        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
