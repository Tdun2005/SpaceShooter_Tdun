using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [Header("UI")]
    public Slider healthSlider;

    protected override void Start()
    {
        base.Start();

        if (healthSlider != null)
        {
            healthSlider.maxValue = defaultHealthPoint;
            healthSlider.value = healthPoint;
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (healthSlider != null)
        {
            healthSlider.value = healthPoint;
        }
    }

    protected override void Die()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.GameOver();
        }

        base.Die();
    }
}
