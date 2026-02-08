using UnityEngine;

public class Health : MonoBehaviour
{
    public int defaultHealthPoint = 10;
    protected int healthPoint;

    protected virtual void Start()
    {
        healthPoint = defaultHealthPoint;
    }

    public virtual void TakeDamage(int damage)
    {
        healthPoint -= damage;

        if (healthPoint <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
