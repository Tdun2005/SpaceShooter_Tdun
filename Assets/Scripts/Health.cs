using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public int defaultHealthPoint = 10;

    protected int healthPoint;
    protected bool isDead = false;

    protected virtual void Start()
    {
        healthPoint = defaultHealthPoint;
        isDead = false;
    }

    public virtual void TakeDamage(int damage)
    {
        // đã chết thì đéo nhận damage nữa
        if (isDead) return;

        healthPoint -= damage;

        if (healthPoint <= 0)
        {
            healthPoint = 0;
            Die();
        }
    }

    protected virtual void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
}