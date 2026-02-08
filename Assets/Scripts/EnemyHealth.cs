using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp = 3;
    private int currentHp;

    public GameObject explosionPrefab;
    private bool isDead = false;

    void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHp -= damage;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        // Ngừng bắn
        EnemyShoot shoot = GetComponent<EnemyShoot>();
        if (shoot != null)
        {
            shoot.StopShooting();
        }

        // Nổ
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        // Cộng điểm
        if (GameManager.instance != null)
        {
            GameManager.instance.AddScore(10);
        }

        Destroy(gameObject);
    }
}
