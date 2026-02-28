using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [Header("UI")]
    public Slider healthSlider;

    protected override void Start()
    {
        base.Start();

        // setup thanh máu
        if (healthSlider != null)
        {
            healthSlider.maxValue = defaultHealthPoint;
            healthSlider.value = healthPoint;
        }
    }

    public override void TakeDamage(int damage)
    {
        // nếu đã chết rồi thì khỏi trừ máu
        if (isDead) return;

        base.TakeDamage(damage);

        // cập nhật UI
        if (healthSlider != null)
        {
            healthSlider.value = Mathf.Clamp(healthPoint, 0, defaultHealthPoint);
        }
    }

    protected override void Die()
    {
        // khóa bắn
        PlayerShoot shoot = GetComponent<PlayerShoot>();
        if (shoot != null)
        {
            shoot.DisableShoot();
        }

        // Game Over
        if (GameManager.instance != null)
        {
            GameManager.instance.GameOver();
        }

        base.Die();
    }
}