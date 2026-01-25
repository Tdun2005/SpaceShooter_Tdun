using UnityEngine;

public class PlanetDrift : MonoBehaviour
{
    public float speed = 0.3f;
    public float resetY = -6f;
    public float startY = 6f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= resetY)
        {
            float randomX = Random.Range(-3f, 3f);
            transform.position = new Vector3(randomX, startY, transform.position.z);
        }
    }
}
