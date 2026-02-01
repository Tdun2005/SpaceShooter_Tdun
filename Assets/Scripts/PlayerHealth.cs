using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 50;
    private int currentHp;

    [Header("UI")]
    public Slider healthSlider;

    void Start()
    {
        currentHp = maxHp;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHp;
            healthSlider.value = currentHp;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (healthSlider != null)
        {
            healthSlider.value = currentHp;
        }

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.GameOver();
        }

        Destroy(gameObject);
    }
}
