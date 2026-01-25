using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    public float speed = 1f;
    private float height;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= startPos.y - height)
        {
            transform.position = startPos;
        }
    }
}
