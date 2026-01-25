using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 2f;
    public float destroyY = -10f; // ra khỏi màn hình xa mới chết

    void Update()
    {
        // enemy bay xuống
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // chỉ destroy khi đi QUÁ XA màn hình
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }
}
