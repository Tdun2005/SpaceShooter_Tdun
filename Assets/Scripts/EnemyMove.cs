using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 2f;

    private float minY;

    void Start()
    {
        // lấy đáy màn hình theo camera
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        minY = bottomLeft.y - 1f; // ra khỏi màn hình hẳn mới chết
    }

    void Update()
    {
        MoveDown();
        CheckOutOfScreen();
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void CheckOutOfScreen()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
