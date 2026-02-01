using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1.5f;

    private bool isAlive = true;
    private bool canShoot = false;

    void Start()
    {
        // chờ enemy vào màn hình rồi mới cho bắn
        InvokeRepeating(nameof(Shoot), 1f, fireRate);
    }

    void Update()
    {
        CheckInCamera();
    }

    void Shoot()
    {
        if (!isAlive) return;
        if (!canShoot) return;
        if (bulletPrefab == null) return;

        // spawn đạn hơi lệch xuống dưới cho đẹp + không đụng collider
        Vector3 spawnPos = transform.position + Vector3.down * 0.5f;
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
    }

    void CheckInCamera()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // enemy đã lọt hoàn toàn vào màn hình
        if (viewPos.y < 1f && viewPos.y > 0f)
        {
            canShoot = true;
        }
    }

    // gọi khi enemy chết
    public void StopShooting()
    {
        isAlive = false;
        CancelInvoke(nameof(Shoot));
    }

    void OnDestroy()
    {
        CancelInvoke();
    }
}
