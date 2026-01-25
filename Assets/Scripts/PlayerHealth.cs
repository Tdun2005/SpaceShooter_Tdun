using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 3;
    private int currentHp;

    void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Game Over
        if (GameManager.instance != null)
        {
            GameManager.instance.GameOver();
        }

        Destroy(gameObject);
    }
}
