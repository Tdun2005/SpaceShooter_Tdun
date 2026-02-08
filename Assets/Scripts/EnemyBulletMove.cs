using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    public float speed = 5f;
    public float destroyY = -7f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(1);
            }

            Destroy(gameObject);
        }
    }
}
