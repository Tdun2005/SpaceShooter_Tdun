using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Bullet")]
    public GameObject bulletPrefab;
    public float fireRate = 0.3f;

    // vị trí bắn – mũi máy bay
    public Vector3 shootOffset = new Vector3(0f, 0.6f, 0f);

    [Header("Sound")]
    public AudioSource shootSound;

    private float fireTimer = 0f;
    private bool canShoot = true;

    void Update()
    {
        // nếu game over thì cấm bắn
        if (!canShoot) return;

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

        // phát âm thanh bắn
        if (shootSound != null)
        {
            shootSound.Play();
        }
    }

    // gọi khi player chết
    public void DisableShoot()
    {
        canShoot = false;
    }
}