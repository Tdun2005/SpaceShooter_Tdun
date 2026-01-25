using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp = 3;
    public GameObject explosionPrefab;

    private bool isDead = false;

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        // Ngừng bắn ngay
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

        // Nếu có GameManager thì cộng điểm
        if (GameManager.instance != null)
        {
            GameManager.instance.AddScore(10);
        }

        Destroy(gameObject);
    }
}
