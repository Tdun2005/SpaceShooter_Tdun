using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1.5f;

    private bool isAlive = true;

    void Start()
    {
        // bắt đầu bắn sau 1 giây
        InvokeRepeating(nameof(Shoot), 1f, fireRate);
    }

    void Shoot()
    {
        // nếu enemy đã chết thì đéo bắn nữa
        if (!isAlive) return;

        if (bulletPrefab == null) return;

        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    // gọi khi enemy chết
    public void StopShooting()
    {
        isAlive = false;
        CancelInvoke(nameof(Shoot));
    }

    void OnDestroy()
    {
        // đảm bảo enemy bị destroy thì ngừng bắn luôn
        CancelInvoke();
    }
}
