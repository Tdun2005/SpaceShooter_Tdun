using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.3f;

    // vị trí bắn – mũi máy bay
    public Vector3 shootOffset = new Vector3(0f, 0.6f, 0f);

    private float fireTimer = 0f;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null) return;

        Vector3 spawnPos = transform.position + shootOffset;
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
    }
}
